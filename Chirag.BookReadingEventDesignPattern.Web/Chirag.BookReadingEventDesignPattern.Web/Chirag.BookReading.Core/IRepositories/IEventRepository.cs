using Chirag.BookReading.Core.Entities;
using Chirag.BookReading.Core.IRepositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chirag.BookReading.Core.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IList<Event>> GetEvents();
        Task<Event> ViewDetails(int eventId);
        Task<int> CreateEvent(Event _event);

        int UpdateEvent(Event _event);
        Task<IList<Event>> MyEvents(string organiser);

        Task<IList<Comment>> GetAllCommentByEventId(int eventId);
    }
}
