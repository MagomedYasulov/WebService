using Microsoft.AspNetCore.Mvc;
using WebService.Abstractions;
using WebService.ViewModels.Request;
using WebService.ViewModels.Resposne;

namespace WebService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessagesController : BaseController
    {
        private readonly IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService) 
        {
            _messagesService = messagesService;
        }

        [HttpGet("{messageId}")]
        public async Task<ActionResult<MessageDto>> Get(int messageId)
        {
            var message = await _messagesService.Get(messageId);
            return Ok(message);
        }

        [HttpGet]
        public async Task<ActionResult<MessageDto[]>> Get(MessageFilter filter)
        {
            var messages = await _messagesService.Get(filter);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> Create(CreateMessageDto model)
        {
            var message = await _messagesService.Create(model);
            return Ok(message);
        }

        [HttpPut("{messageId}")]
        public async Task<ActionResult<MessageDto>> Update(int messageId, UpdateMessageDto model)
        {
            var message = await _messagesService.Update(messageId, model);
            return Ok(message);
        }

        [HttpDelete("{messageId}")]
        public async Task<ActionResult> Delete(int messageId)
        {
            await _messagesService.Delete(messageId);
            return Ok();
        }
    }
}
