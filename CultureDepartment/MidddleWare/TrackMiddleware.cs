using Newtonsoft.Json;
using System.Net;

namespace CultureDepartment.API.MidddleWare
{
    public class TrackMiddleware
    {
        private readonly RequestDelegate _next;

        public TrackMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestSeq = Guid.NewGuid().ToString();
            context.Items.Add("RequestSequence", requestSeq);
            if ((DateTime.Now.DayOfWeek == DayOfWeek.Friday && DateTime.Now.TimeOfDay >= new TimeSpan(13, 0, 0))
                  || (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.TimeOfDay < new TimeSpan(20, 0, 0)))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                string responseMessage = "Today is Shabbat. The service is not active.";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(responseMessage));
            }
            else
                await _next(context);
        }
    }
    public static class TrackMiddlewareExtensions
    {
        public static IApplicationBuilder UseTrack(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TrackMiddleware>();
        }
    }
}
