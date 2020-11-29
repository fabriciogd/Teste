using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Security.Claims;
using Web.Extensions;

namespace UnitTest
{
    [TestClass]
    public class ClaimsPrincipalExtensionsTest
    {
        [TestMethod]
        public void IsAdmin_WhenCalled_ReturnsTrueResult()
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "Test"),
                new Claim(ClaimTypes.Name, "Test"),
                new Claim(ClaimTypes.Email, "Test@test.com"),
                new Claim(ClaimTypes.Role, Application.Structs.Role.Administrator)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            Assert.IsTrue(principal.IsAdmin());
        }

        [TestMethod]
        public void IsAdmin_WhenCalled_ReturnsFalseResult()
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "Test"),
                new Claim(ClaimTypes.Name, "Test"),
                new Claim(ClaimTypes.Email, "Test@test.com"),
                new Claim(ClaimTypes.Role, Application.Structs.Role.Seller)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            Assert.IsFalse(principal.IsAdmin());
        }
    }
}
