using WebService.ViewModels.Request;
using WebService.ViewModels.Resposne;

namespace WebService.Abstractions
{
    public interface IMessagesService
    {
        public Task<MessageDto> Get(int id);
        public Task<MessageDto[]> Get(MessageFilter filter);
        public Task<MessageDto> Create(CreateMessageDto model);
        public Task<MessageDto> Update(int messageId,UpdateMessageDto model);
        public Task Delete(int id);
    }
}
