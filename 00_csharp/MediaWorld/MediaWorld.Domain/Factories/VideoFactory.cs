using MediaWorld.Domain.Models;
using MediaWorld.Domain.Interfaces;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Factories
{
  public class VideoFactory : IFactory {

    public AMedia Create<T>() where T : AMedia, new()
    {
      return new T();
    }
  }
}