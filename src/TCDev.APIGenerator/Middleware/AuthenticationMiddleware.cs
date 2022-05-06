using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Extension.Auth;
using TCDev.APIGenerator.Model;

namespace TCDev.APIGenerator.Middleware
{
    public class AuthenticationMiddleware
    {

		private readonly RequestDelegate next;
		private readonly ILoggerFactory logger;
		private readonly IConfiguration config;

		public AuthenticationMiddleware(RequestDelegate next,

			ILoggerFactory logger,
			IConfiguration config)
		{
			this.next = next;
			this.logger = logger;
			this.config = config;

		}

		public async Task Invoke(
			HttpContext context,
			AuthDbContext _db,
			ILogger<AuthDbContext> authLogger)
		{

			// Ignore for endpoints that should be unauthed
			var fullUrl = context.Request.GetDisplayUrl();
			logger.CreateLogger("HTTPRequest").Log(LogLevel.Information, $"Req in > {fullUrl}");

			if (IsStaticFile(fullUrl) || IsApiOrCallback(fullUrl))
			{
				await this.next(context);
				return;
			}

			// Lets see if we're already authenticated
			if (context.User.Identity.IsAuthenticated)
			{
				logger.CreateLogger("HTTPRequest").Log(LogLevel.Information, "Login Succeeded");
				AppUser? appUser = null;
				Auth0User authUser = null;
				var objectId = context.User.GetObjectId();

				if (!string.IsNullOrEmpty(objectId) && authUser != null)
				{
					//var cacheKey = string.Format("Users_Login_{0}_aa", objectId);
					AppUser cachedEntry = null; //await redis.GetAsync<AppUser>(cacheKey);

					if (cachedEntry == null)
					{
						appUser = _db.Users.Any() ?
							await _db.Users.Include("Tenant").FirstOrDefaultAsync(p =>
								   p.UserLookup == objectId
								&& p.PrimaryEmail == authUser.Email) : null;
						// We have a user -> just load it
						if (appUser != null)
						{
							//await redis.AddAsync<AppUser>(appUser, cacheKey, DateTime.Now.AddHours(1));
							context.SetUser(appUser);
							await this.next(context);
							return;
						}
						else // We dont have a user, add a new user and tag as new, add regular if domain already exists. 
						{
							var userId = string.IsNullOrEmpty(objectId) ? System.Guid.NewGuid().ToString() : objectId;

							var user = new AppUser()
							{
								AppUserId = new Guid(),
								ObjectId = userId,
								UserLookup = userId,
								Created = DateTime.Now,
								PrimaryEmail = context.User.GetClaimValue("name"),
								SID = objectId,
								IsNewUser = true
							};


							_db.Users.Add(user);
							await _db.SaveChangesAsync();
							//await redis.AddAsync<AppUser>(appUser, cacheKey, DateTime.Now.AddMinutes(10));
							context.SetUser(user);

							await this.next(context);
							return;
						}

					}
					else
					{
						context.SetUser(cachedEntry);
						await this.next(context);
						return;
					}

				}
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Error authenticating the request. Login succeeded but the user is missing important claims - 'ObjectIdentifier' missing");
				return;
			}
			else
			{
				context.Response.Redirect("https://sts.maxdev.localhost/account/login");
				await this.next(context);
				return;
			}

		}

		public bool IsStaticFile(string pUrl)
		{
			if (pUrl.ToLower().Contains(".css")
				|| pUrl.ToLower().Contains("images")
				|| pUrl.ToLower().Contains(".js")
				|| pUrl.ToLower().Contains(".png")
				|| pUrl.ToLower().Contains(".jpg"))
			{
				return true;
			}
			return false;
		}

		public bool IsApiOrCallback(string pUrl)
		{
			if (
				pUrl.Contains("swagger")
				|| pUrl.Contains("callback")
				|| pUrl.Contains("oidc")
				|| pUrl.Contains("login")
				|| pUrl.Contains("logout")
				|| pUrl.Contains("callbacks"))
			{
				return true;
			}
			return false;
		}
	}
}
