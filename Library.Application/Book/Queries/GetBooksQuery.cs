using Library.Application.Common.Dto;
using MediatR;

namespace Library.Application.Book.Queries;

public class GetBooksQuery : IRequest<List<BookDto>>
{
}

