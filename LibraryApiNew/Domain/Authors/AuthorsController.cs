using System.Threading.Tasks;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApiNew.Controllers;
using LibraryApiNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryApiNew.Domain.Authors
{
    public class AuthorsController : BelongsToUserController<Author>
    {
        public AuthorsController(
            IJsonApiContext jsonApiContext,
            IResourceService<Author> resourceService,
            ILoggerFactory loggerFactory
        ) : base(jsonApiContext, resourceService, loggerFactory)
        { }
    }
}