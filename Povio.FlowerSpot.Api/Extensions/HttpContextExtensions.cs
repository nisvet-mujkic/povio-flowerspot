namespace Povio.FlowerSpot.Api.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetClaimValue(this HttpContext httpContext, string type)
        {
            var claim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == type);

            return claim != null ? claim.Value : string.Empty;
        }
    }
}