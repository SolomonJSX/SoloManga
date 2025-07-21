using System.Security.Claims;

namespace SoloManga.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var userClaim = user.FindFirst(ClaimTypes.NameIdentifier) ??
                        user.FindFirst("sub") ??
                        throw new UnauthorizedAccessException("User ID claim not found.");

        if (int.TryParse(userClaim.Value, out int userId))
        {
            return userId;
        } 
        throw new UnauthorizedAccessException("Invalid user ID claim.");
    }
}