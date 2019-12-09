using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
  public class Pizza //this is about the view, this will be presented. We dont need price or active
  {

     public string Crust {get; set; }

     public string Size {get; set; }
     public List<string> Crusts {get; set; }
     public List<string> Sizes {get; set; }

     public Pizza()
     {
       Crusts = new List<string>{"thin", "regular", "deepdish"} ;  //needs to come from storing
       Sizes = new List<string>{"small", "medium", "large"} ;
     }

  }
}