using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApiNew.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApiNew.Domain.Authors
{
    public class AuthorsController : JsonApiController<Author>
    {
        public AuthorsController(
            IJsonApiContext jsonApiContext,
            IResourceService<Author> resourceService,
            ILoggerFactory loggerFactory
        ) : base(jsonApiContext, resourceService, loggerFactory)
        { }
    }
}