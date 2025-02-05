using AutoMapper;
using WebService.Data.Entites;
using WebService.ViewModels.Request;
using WebService.ViewModels.Resposne;

namespace WebService.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CreateMessageDto, Message>();
            CreateMap<UpdateMessageDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}
