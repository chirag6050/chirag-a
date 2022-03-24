using Microsoft.EntityFrameworkCore;
using Chirag.BookReading.Core.Entities.Base;
using Chirag.BookReading.Core.IRepositories.Base;
using Chirag.BookReading.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirag.BookReading.Infrastructure.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly EventContext _eventContext;

        public Repository(EventContext eventContext)
        {
            this._eventContext = eventContext ?? throw new ArgumentNullException(nameof(eventContext)); ;
        }


    }
}
