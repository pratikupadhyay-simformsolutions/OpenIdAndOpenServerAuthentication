using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer4_Demo.IdentityConfiguration
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "56892347",
                Username = "username",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Email, "pratik.u@simformsolutions.com"),
                    new Claim(JwtClaimTypes.Role, "admin"),
                    new Claim(JwtClaimTypes.WebSite, "https://google.com")
                }
            }
        };
        }
    }
}
