using JWT.Token.Api.Options;
using Microsoft.Extensions.Options;

namespace JWT.Token.Api.Services;

public class GetOptionsService : IGetOptionsService
{
    private readonly JwtOptions _jwtOptions;

    public GetOptionsService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    public JwtOptions GetJwtOptions()
    {
        return _jwtOptions;
    }
}
