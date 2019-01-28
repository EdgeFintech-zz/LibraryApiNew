using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Models;

namespace LibraryApiNew.Models
{
    public abstract class BelongsToUser : Identifiable
    {
          public int UserId { get; set; }        
          public User User { get; set; }
        
          [Attr("username"), NotMapped] public string Username { get => User?.Username; set {} }
          // Video 51 issue fixed 1-20-2019. UserName property must have a dedicated setter.
          // Username { get => User?.Username; } should be Username { get => User?.Username; set {} }
    }
}