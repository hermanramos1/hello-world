using MediaWorld.Domain.Models;
using MediaWorld.Domain.Interfaces;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Factories
{
  public class AudioFactory : IFactory {

    public AMedia Create<T>() where T : AMedia, new()
    {
      return new T();
      // switch (type)
      // {
      //   case "book":
      //     return new Book();
      //   case "song":
      //     return new Song();
      //   default: 
      //     return null;
      // }
    }
  }
}