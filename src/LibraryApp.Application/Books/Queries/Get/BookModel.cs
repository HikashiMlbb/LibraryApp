using AutoMapper;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Books.Queries.Get;

public sealed class BookModel : IMapWith<Book>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? AuthorId { get; set; }
    public DateTime PublicationDate { get; set; }

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<Book, BookModel>()
            .ForMember(x => x.Id, opt
                => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Title, opt
                => opt.MapFrom(x => x.Header.Title))
            .ForMember(x => x.Description, opt 
                => opt.MapFrom(x => x.Header.Description))
            .ForMember(x => x.AuthorId, opt 
                => opt.MapFrom(x => x.Author == null ? (Guid?)null : x.Author.Id ))
            .ForMember(x => x.PublicationDate, opt 
                => opt.MapFrom(x => x.PublicationDate));
    }
}