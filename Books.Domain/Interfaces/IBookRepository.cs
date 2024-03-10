using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Application.DTOs.Create;

namespace Books.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task Create(BookCreateModel model);
    }
}