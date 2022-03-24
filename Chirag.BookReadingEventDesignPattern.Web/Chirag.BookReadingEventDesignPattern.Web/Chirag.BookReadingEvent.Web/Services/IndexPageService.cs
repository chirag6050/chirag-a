using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chirag.BookReadingEvent.Web.Interfaces;

namespace Chirag.BookReadingEvent.Web.Services
{
    public class IndexPageService  :IIndexPageService
    {
        private readonly IMapper _mapper;
        public IndexPageService(IMapper mapper)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
