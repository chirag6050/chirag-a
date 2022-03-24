using Chirag.BookReading.Core.IRepositories;
using Chirag.BookReading.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirag.BookReading.Infrastructure.Repository
{
    public class UnitOfWork :IUnitofwork
    {
        private readonly EventContext _context;
         public UnitOfWork(EventContext context)
        {
            _context = context;
        }
        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
