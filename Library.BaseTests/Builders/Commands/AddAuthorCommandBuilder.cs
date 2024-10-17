using Library.Application.Common.Dto;
using Library.BaseTests.Builders.Dto;

namespace Library.BaseTests.Builders.Commands;

public class AddAuthorCommandBuilder
{
    private AuthorDto _dto = new AddAuthorDtoBuilder().Build();
    
    public AddAuthorCommandBuilder WithDto(AuthorDto dto)
    {
        _dto = dto;
        return this;
    }
}