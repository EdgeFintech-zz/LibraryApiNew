using System;
using System.Linq;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Internal.Query;
using JsonApiDotNetCore.Services;
using LibraryApiNew.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApiNew.Domain.Authors
{
    public class AuthorsRepository : DefaultEntityRepository<Author>
    {
        public AuthorsRepository(
            ILoggerFactory loggerFactory,
            IJsonApiContext jsonApiContext,
            IDbContextResolver contextResolver
        ) : base(loggerFactory, jsonApiContext, contextResolver)
        { }

        public override IQueryable<Author> Filter(IQueryable<Author> authors, FilterQuery filterQuery)
        {
            if (filterQuery.Attribute.Equals("query")) 
            {
                return authors.Where(a => 
                    a.first.Contains(filterQuery.Value, StringComparison.OrdinalIgnoreCase) ||
                    a.last.Contains(filterQuery.Value, StringComparison.OrdinalIgnoreCase));
            }

            return base.Filter(authors, filterQuery);
        }
    }
}