using Chirag.BookReading.Core.Entities;
using Chirag.BookReading.Core.IRepositories;
using Chirag.BookReading.Infrastructure.Data;
using Chirag.BookReading.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirag.BookReading.Infrastructure.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly EventContext _commentContext;
        private readonly IUnitofwork _unitofwork;

        public CommentRepository(EventContext commentContext, IUnitofwork unitofwork) : base(commentContext)
        {
            this._commentContext = commentContext;
            this._unitofwork = unitofwork;
        }
        public async Task<int> PostComment(Comment response)
        {
            var newComment = new Comment()
            {
                comment = response.comment,
                //timeStamp = response.timeStamp,
                EventId = response.EventId
            };
            await _commentContext.Comment.AddAsync(newComment);
            /*_commentContext.SaveChanges();*/
            await _unitofwork.CompleteAsync();
            return newComment.Id;
        }

        public async Task<IList<Comment>> GetComments()
        {
            return await _commentContext.Comment.OrderBy(x => x.timeStamp).ToListAsync();
        }
        public async Task<Comment> ViewComment(int commentId)
        {
            return await _commentContext.Comment.FindAsync(commentId);
        }
        public int EditComment(Comment response)
        {
            _commentContext.Comment.Update(response);
            /* _commentContext.SaveChanges();*/
            _unitofwork.CompleteAsync();
            return response.Id;
        }


    }
}
