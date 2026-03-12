using Microsoft.AspNetCore.Http;
using StudentAdminPortal.Services;
using System.Threading.Tasks;

namespace StudentAdminPortal.Middleware
{
	public class AdminAuthMiddleware
	{
		private readonly RequestDelegate _next;

		public AdminAuthMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IAuthService authService)
		{
			var path = context.Request.Path;

			// check if request is for /Admin
			if (path.StartsWithSegments("/Admin"))
			{
				if (!authService.IsAuthenticated())
				{
					context.Response.Redirect("/Home/AccessDenied");
					return;
				}
			}

			await _next(context);
		}
	}
}