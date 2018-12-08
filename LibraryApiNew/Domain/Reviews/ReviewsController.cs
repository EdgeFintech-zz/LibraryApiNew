using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApiNew.Controllers;
using LibraryApiNew.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApiNew.Domain.Reviews
{
    public class ReviewsController : BelongsToUserController<Review>
    {
        public ReviewsController(
            IJsonApiContext jsonApiContext, 
            IResourceService<Review> resourceService, 
            ILoggerFactory loggerFactory
        ) : base(jsonApiContext, resourceService, loggerFactory)
        { }
    }
}