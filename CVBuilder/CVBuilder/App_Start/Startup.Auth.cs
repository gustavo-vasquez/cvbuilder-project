using CVBuilder.ViewModels.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.MicrosoftAccount;
using Owin;
using Owin.Security.Providers.GitHub;
using Owin.Security.Providers.LinkedIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CVBuilder
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/SignIn"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "450b53a8-5f7f-4e66-bd7f-5098e0109208",
            //    clientSecret: "Ud?_DN_4nr8?yRFdIEfNrqT2E1BU?D1n");

            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountAuthenticationOptions()
            {
                ClientId = "450b53a8-5f7f-4e66-bd7f-5098e0109208",
                ClientSecret = "0e0PlK02Fc~6z38K~~sX4mbBFj5G-~J-6U",
                Provider = new MicrosoftAccountAuthenticationProvider()
                {
                    OnAuthenticated = (context) =>
                    {
                        //context.Identity.AddClaim(new Claim(
                        //    "urn:microsoftaccount:accesstoken", context.AccessToken));
                        context.Identity.AddClaim(new Claim(
                            ClaimTypes.GivenName, context.FirstName));
                        context.Identity.AddClaim(new Claim(
                            ClaimTypes.Surname, context.LastName));

                        return System.Threading.Tasks.Task.FromResult(0);
                    }
                }
            });

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "6621956044-7ta2f0u37nqcnfvf2sp2fpuo5q6lm840.apps.googleusercontent.com",
                ClientSecret = "UXwpzfT77w2_H057ASkhiFUl",
                CallbackPath = new PathString("/signin-google"),
                Provider = new GoogleOAuth2AuthenticationProvider()
                {
                    OnAuthenticated = (context) =>
                    {
                        //context.Identity.AddClaim(new Claim(
                        //    "urn:google:accesstoken", context.AccessToken));
                        context.Identity.AddClaim(new Claim(
                            "urn:google:picture", (string)context.User["picture"]));

                        return System.Threading.Tasks.Task.FromResult(0);
                    }
                }
            });

            app.UseLinkedInAuthentication(
                clientId: "780tqq6sx49ybw",
                clientSecret: "53NNlHcFrP0qCGBs");

            //app.UseGitHubAuthentication(
            //    clientId: "6706aeb25bf4a2242f61",
            //    clientSecret: "52e87a1e5eb1c1d1fcd7e7b925a170c13e13a91a");

            app.UseGitHubAuthentication(new GitHubAuthenticationOptions()
            {
                ClientId = "6706aeb25bf4a2242f61",
                ClientSecret = "52e87a1e5eb1c1d1fcd7e7b925a170c13e13a91a",
                Provider = new GitHubAuthenticationProvider()
                {
                    OnAuthenticated = (context) =>
                    {
                        //context.Identity.AddClaim(new Claim(
                        //    "urn:github:accesstoken", context.AccessToken));
                        context.Identity.AddClaim(new Claim(
                            "urn:github:avatar_url", (string)context.User["avatar_url"]));

                        return System.Threading.Tasks.Task.FromResult(0);
                    }
                }
            });
        }
    }
}