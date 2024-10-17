using Library.Application.Common.Dto;

namespace Library.BaseTests.Builders.Dto;

public class AddAuthorDtoBuilder
{

    private readonly AuthorDto _authorDto;
    
    public AddAuthorDtoBuilder() 
    { 
        _authorDto = new AuthorDto();
    }
    
    public AddAuthorDtoBuilder WithId(string id) 
    { 
        _authorDto.Id = id; 
        return this;
    }

    public AddAuthorDtoBuilder WithFirstName(string firstName)
    { 
        _authorDto.FirstName = firstName; 
        return this;
    }
    
    public AddAuthorDtoBuilder WithLastName(string lastName) 
    { 
        _authorDto.LastName = lastName; 
        return this;
    }
    
    public AuthorDto Build() 
    { 
        return _authorDto;
    }
}
