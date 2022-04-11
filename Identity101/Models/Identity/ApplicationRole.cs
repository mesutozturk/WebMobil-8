using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Identity101.Models.Identity;

public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }

    public ApplicationRole()
    {
    }

    public ApplicationRole(string roleName, string description)
        : base(roleName)
    {
        this.Description = description;
    }
}