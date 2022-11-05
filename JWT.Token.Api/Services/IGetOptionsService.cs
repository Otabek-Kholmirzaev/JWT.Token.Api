using JWT.Token.Api.Options;

namespace JWT.Token.Api.Services;

public interface IGetOptionsService 
{
    JwtOptions GetJwtOptions();
}
