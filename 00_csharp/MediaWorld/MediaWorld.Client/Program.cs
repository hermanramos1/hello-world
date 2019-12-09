using System;
using System.Threading;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Factories;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Singletons;
using MediaWorld.Storing.Repositories;
using Serilog;

namespace MediaWorld.Client
{
  /// <summary>
  /// contains the starting method
  /// </summary>
  internal class Program
  {
    private static MediaRepository _repository = new MediaRepository();
    /// <summary>
    /// starts the application
    /// </summary>
    private static void Main()
    {
      (new Program()).ApplicationStart();
      Play();
      Log.Warning("end of Main Method");
    }

    private void ApplicationStart()
    {
      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("log.txt")
        .CreateLogger();
    }

    private static void Play()
    {
      Log.Information("Play Method");
      var mediaPlayer = MediaPlayerSingleton.Instance;

      foreach (var item in _repository.MediaLibrary)
      {
        Log.Debug("{@item}", item.Title);
        mediaPlayer.Execute(item.Play, item);
      }
    }
     
      }
      
      }
  
  
