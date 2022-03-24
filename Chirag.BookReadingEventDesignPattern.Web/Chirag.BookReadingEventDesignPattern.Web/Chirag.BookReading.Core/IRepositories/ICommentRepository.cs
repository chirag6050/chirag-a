using Chirag.BookReading.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirag.BookReading.Core.IRepositories
{
           public interface ICommentRepository
        {
            Task<int> PostComment(Comment response);

            Task<IList<Comment>> GetComments();

            Task<Comment> ViewComment(int commentId);

            int EditComment(Comment response);
        }
}
