using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Photo : AVideo {

    public Photo(){
      Initialize();
    }
    public Photo(string title){
      Initialize(title);
    }

    private void Initialize(string title = "Untitled"){
      Title = title;
    }
  }
}
