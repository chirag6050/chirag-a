using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirag.BookReading.Core.IRepositories
{
    public interface IUnitofwork
    {
        Task<bool> CompleteAsync();
    }
}
