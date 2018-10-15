using System.Collections.Generic;
using JsonApiDotNetCore.Models;
using LibraryApiNew.Models;

namespace LibraryApiNew.Domain.Users
{
    public class UserResource : ResourceDefinition<User>
    {
        protected override List<AttrAttribute> OutputAttrs() => Remove(u => new { u.Password, u.PasswordConfirmation });
    }
}