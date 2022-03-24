using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Chirag.BookReading.Application.Models;
using Chirag.BookReadingEvent.Web.Models;
using Chirag.BookReadingEvent.Application.Models;

namespace Chirag.BookReadingEvent.Web.Mapper
{
    public class EventProfiles :Profile
    {
        public EventProfiles()
        {
            CreateMap<EventModel, EventViewModel>().ReverseMap();
            CreateMap<SignUpModel, SignUpViewModel>().ReverseMap();
            CreateMap<LoginModel, LoginViewModel>().ReverseMap();
            CreateMap<CommentModel, CommentViewModel>().ReverseMap();
        }

    }
}
