using Chirag.BookReadingEvent.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chirag.BookReadingEvent.Application.Interfaces
{
    public interface IEventService
    {
        Task<IList<EventModel>> GetEvents();
        Task<EventModel> ViewDetails(int eventId);

        Task<int> CreateEvent(EventModel eventModel);

        int UpdateEvent(EventModel eventModel);

        Task<IList<EventModel>> MyEvents(string organiser);

        Task<IList<CommentModel>> GetAllCommentByEventId(int eventId);
    }
}
