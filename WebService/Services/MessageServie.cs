using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebService.Abstractions;
using WebService.Data;
using WebService.Data.Entites;
using WebService.Exceptions;
using WebService.Hubs;
using WebService.ViewModels.Request;
using WebService.ViewModels.Resposne;

namespace WebService.Services
{
    public class MessageServie : IMessagesService
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<MessagesHub> _messageHub;
        private readonly ILogger<MessageServie> _logger;
        private readonly ApplicationContext _context;

        public MessageServie(
            IHubContext<MessagesHub> messageHub,
            ILogger<MessageServie> logger,
            IMapper mapper,
            ApplicationContext context)
        {
            _mapper = mapper;
            _messageHub = messageHub;
            _logger = logger;
            _context = context;
        }

        public async Task<MessageDto> Create(CreateMessageDto model)
        {
            var message = _mapper.Map<Message>(model);
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            var messageDto = _mapper.Map<MessageDto>(message);
            await _messageHub.Clients.All.SendAsync("OnMessageCreate", messageDto);

            _logger.LogInformation("Create message | Id: {Id} | Number {Number}", messageDto.Id, messageDto.Number);

            return messageDto;
        }

        public async Task<MessageDto> Get(int id)
        {
            var message = await _context.Messages.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
                throw new ServiceException("Message Not Found", $"Message with id {id} not found.", StatusCodes.Status404NotFound);

            return _mapper.Map<MessageDto>(message);
        }

        public async Task<MessageDto[]> Get(MessageFilter filter)
        {
            var messages = await _context.Messages.AsNoTracking().Where(m => m.CreatedAt >= filter.StartTime && m.CreatedAt <= filter.EndTime).ToArrayAsync();
            return _mapper.Map<MessageDto[]>(messages);
        }

        public async Task<MessageDto> Update(int id, UpdateMessageDto model)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
                throw new ServiceException("Message Not Found", $"Message with id {id} not found.", StatusCodes.Status404NotFound);

            message.Text = model.Text;
            await _context.SaveChangesAsync();

            var messageDto = _mapper.Map<MessageDto>(message);
            await _messageHub.Clients.All.SendAsync("OnMessageUpdate", messageDto);

            _logger.LogInformation("Update message | Id: {Id} | Number {Number}", messageDto.Id, messageDto.Number);

            return messageDto;
        }

        public async Task Delete(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
                throw new ServiceException("Message Not Found", $"Message with id {id} not found.", StatusCodes.Status404NotFound);

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Delete message | Id: {Id} | Number {Number}", message.Id, message.Number);
        }
    }
}
