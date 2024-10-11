using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Infrastructure.Services;
public class TokenService : ITokenService
{
    private readonly AppSettings _appSettings;

    public TokenService(IOptions<AppSettings> options)
    {
        _appSettings = options.Value;
    }
    public string GetToken(Guid userId,Guid profileId,string providersIds)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_appSettings.JwtSettings.JwtEncryptionKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim("ProfileId",profileId.ToString()),
                    new Claim("ProvidersIds",providersIds)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.JwtExpireAfterMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _appSettings.JwtSettings.Audience,
            Issuer = _appSettings.JwtSettings.Issuer,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    public string GeneratePortalToken(User user, bool isInstructor = false)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_appSettings.JwtSettings.JwtEncryptionKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Email),
            new Claim("isInstructor", isInstructor.ToString().ToLower())
        };
                //claims.Add(new Claim(ClaimTypes.Role, "Admin"));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.JwtExpireAfterMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _appSettings.JwtSettings.Audience,
            Issuer = _appSettings.JwtSettings.Issuer,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


    // roleName is now mandatory
    public string GenerateDashboardToken(User user, string roleName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_appSettings.JwtSettings.JwtEncryptionKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        if (roleName != null)
        {
            claims.Add(new Claim(ClaimTypes.Role, "7A8CDDE7-B46F-4E1B-8EE0-DFAE63ACF92F"));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {

            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.JwtExpireAfterMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _appSettings.JwtSettings.Audience,
            Issuer = _appSettings.JwtSettings.Issuer,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }



    public string GetAdminToken(User admin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_appSettings.JwtSettings.JwtEncryptionKey);

        var claims = new List<Claim> { 
            new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()) ,
            new Claim(ClaimTypes.Name, admin.FirstName) ,
            new Claim(ClaimTypes.Email, admin.Email) ,
        };
       
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.JwtExpireAfterMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience=_appSettings.JwtSettings.Audience,
            Issuer=_appSettings.JwtSettings.Issuer,
            
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
