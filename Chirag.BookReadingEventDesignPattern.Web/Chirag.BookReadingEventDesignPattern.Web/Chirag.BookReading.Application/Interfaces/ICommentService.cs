using Chirag.BookReadingEvent.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chirag.BookReadingEvent.Application.Interfaces
{
    public interface ICommentService
    {
        Task<int> PostComment(CommentModel response);

        Task<IList<CommentModel>> GetComments();

        Task<CommentModel> ViewComment(int commentId);

        int EditComment(CommentModel response);

    }
}
