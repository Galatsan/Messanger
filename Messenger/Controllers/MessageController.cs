using AutoMapper;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;

        public MessageController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IndexMessageViewModel> Save([FromBody]CreateMessageViewModel message)
        {
            return new IndexMessageViewModel();
        }
    }
}