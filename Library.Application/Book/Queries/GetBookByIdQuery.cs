using Library.Application.Common.Dto;
using MediatR;

namespace Library.Application.Book.Queries
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; }
        
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
