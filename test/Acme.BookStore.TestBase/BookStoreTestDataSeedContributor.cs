using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Acme.BookStore
{
    public class BookStoreTestDataSeedContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IGuidGenerator _guidGenerator;

        public BookStoreTestDataSeedContributor(
            IRepository<Book, Guid> bookRepository,
            IGuidGenerator guidGenerator)
        {
            _bookRepository = bookRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _bookRepository.InsertAsync(
                new Book
                {
                    Id = _guidGenerator.Create(),
                    Name = "1984",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1949, 06, 08),
                    Price = 21
                }
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Id = _guidGenerator.Create(),
                    Name = "Spinning Silver",
                    Type = BookType.Fantasy,
                    PublishDate = new DateTime(2018, 07, 10),
                    Price = 15
                }
            );
        }
    }
}
