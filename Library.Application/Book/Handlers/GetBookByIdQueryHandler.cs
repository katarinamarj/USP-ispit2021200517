using Library.Application.Book.Queries;
using Library.Application.Common.Dto;
using MediatR;
using MongoDB.Driver;

namespace Library.Application.Book.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        
        private readonly IMongoCollection<Domain.Entities.Book> _books;

        public GetBookByIdQueryHandler(IMongoDatabase database)
        {
            _books = database.GetCollection<Domain.Entities.Book>("Books");
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _books.Find(b => b.BookId == request.Id).FirstOrDefaultAsync();

            if (book == null) return null;

            return new BookDto()
            {
                BookId = book.BookId,
                Name = book.Name,
                Description = book.Description,
                Genre = book.Genre
            };
        }
    }
}