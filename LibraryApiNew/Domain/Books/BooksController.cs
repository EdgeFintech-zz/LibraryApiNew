using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApiNew.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApiNew.Domain.Books
{
    public class BooksController : JsonApiController<Book>
    {
        public BooksController(
            IJsonApiContext jsonApiContext, 
            IResourceService<Book> resourceService, 
            ILoggerFactory loggerFactory
            ) : base(jsonApiContext, resourceService, loggerFactory)
        { }
    }
}