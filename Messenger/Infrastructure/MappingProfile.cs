using AutoMapper;
using Messenger.Models;
using MessengerBL.Models;

namespace Messenger.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMessageViewModel, MessageDTO>();
            CreateMap<MessageDTO, IndexMessageViewModel>();
        }
    }
}
