using AutoMapper;

namespace LibraryApp.Application.Common.Interfaces;

public interface IMapWith<T>
{
    public void CreateMap(Profile profile);
}