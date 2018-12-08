using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace LibraryApiNew.Models
{
    public class Author : BelongsToUser
    {
        [Attr("first")] public string first { get; set; }        
        [Attr("last")] public string last { get; set; }

        [HasMany("books")] public List<Book> Books { get; set; }
    }
}