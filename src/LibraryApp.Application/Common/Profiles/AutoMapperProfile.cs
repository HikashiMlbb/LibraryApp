using AutoMapper;
using LibraryApp.Application.Common.Interfaces;

namespace LibraryApp.Application.Common.Profiles;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        var types = typeof(AutoMapperProfile).Assembly.GetTypes()
            .Where(t => t.IsClass)
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

        foreach (var type in types)
        {
            var methodInfo = type.GetMethod("CreateMap");
            var instance = Activator.CreateInstance(type);
            methodInfo?.Invoke(instance, [this]);
        }
    }
}