using System;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class AsyncCrudAppService<T1, T2, T3, T4, T5, T6>
    {
        private IRepository<Book, Guid> repository;

        public AsyncCrudAppService(IRepository<Book, Guid> repository)
        {
            this.repository = repository;
        }
    }
}