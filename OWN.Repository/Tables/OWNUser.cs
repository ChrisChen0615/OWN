using Microsoft.AspNetCore.Identity;

namespace OWN.Repository.Tables
{
    public class OWNUser : IdentityUser<int>
    {
        public bool IsLockout { get; set; }
    }
}
