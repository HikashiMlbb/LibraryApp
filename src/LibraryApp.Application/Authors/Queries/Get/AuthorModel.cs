using AutoMapper;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Authors.Queries.Get;

public sealed class AuthorModel : IMapWith<Author>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Guid> Books { get; set; } = new List<Guid>();
    public DateTime BirthDay { get; set; }

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<Author, AuthorModel>()
            .ForMember(x => x.Id, opt
                => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Name, opt
                => opt.MapFrom(x => x.Name))
            .ForMember(x => x.Books, opt
                => opt.MapFrom(x => x.Books.Select(y => y.Id)))
            .ForMember(x => x.BirthDay, opt
                => opt.MapFrom(x => x.BirthDay));
    }
}