using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace SecurityPoliceMG.Api.Base;

public class GenericApi : ControllerBase
{
    protected Guid GetLoggedUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (!Guid.TryParse(userId, out var convertedVar))
        {
            throw new ArgumentException("Impossível encontrar o ID do usuário nesse access token");
        }

        return convertedVar;
    }
}