using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using FrequenciaApi.Domain.Models;
using System.Security.Principal;
using System.Text;
using FrequenciaApi.Infra.CrossCutting.IoC;

namespace FrequenciaApi.Services.Auth
{
    public class TokenService
    {
        public object GenerateToken(UsuarioMatricula user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.MatriculaId.ToString(), "Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Usuario.Email ),
                    new Claim(ClaimTypes.Sid, user.Usuario.Id.ToString()),
                }
            );

            var key = Encoding.ASCII.GetBytes(Global.Instance.GetSecret());

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao.AddMinutes(15);

            var handler = new JwtSecurityTokenHandler();

            TokenConfigurations tokenConfigurations = new TokenConfigurations();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            
            return handler.WriteToken(securityToken);
        }
    }
}
