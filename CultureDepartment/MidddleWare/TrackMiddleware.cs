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

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                await context.Response.WriteAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent("Today is Shabbat, The service is not active", System.Text.Encoding.UTF8, "application/json")
                }.ToString());
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
