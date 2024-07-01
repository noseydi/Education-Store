using AutoMapper;

namespace Application.Common.Mapping
{
    public interface IMapForm<T>
    {

       virtual void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());


    }
}
