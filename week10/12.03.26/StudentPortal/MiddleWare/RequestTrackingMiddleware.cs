using Microsoft.AspNetCore.Http;
using StudentPortal.Models;
using StudentPortal.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StudentPortal.Middleware
{
	public class RequestTrackingMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestTrackingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IRequestLogService logService)
		{
			var stopwatch = Stopwatch.StartNew();

			await _next(context);

			stopwatch.Stop();

			var log = new RequestLog
			{
				Url = context.Request.Path,
				ExecutionTimeMs = stopwatch.ElapsedMilliseconds
			};

			logService.AddLog(log);
		}
	}
}