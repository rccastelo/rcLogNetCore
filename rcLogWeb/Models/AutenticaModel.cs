using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcLogTransfers;
using rcLogWeb.Services;

namespace rcLogWeb.Models
{
  public class AutenticaModel
    {
        private readonly string cookieRcLog = "CookieRcLog";

        private readonly IHttpContextAccessor httpContext;

        public AutenticaModel(IHttpContextAccessor pAccessor)
        {
            httpContext = pAccessor;
        }

         public async Task<AutenticaTransfer> Autenticar(AutenticaTransfer pAutentica)
        {
            AutenticaService autenticaService;
            AutenticaTransfer autentica;
            
            try {
                autenticaService = new AutenticaService();

                autentica = await autenticaService.Autenticar(pAutentica);

                if (autentica != null) {
                    if ((autentica.Autenticado) && (!string.IsNullOrEmpty(autentica.Token))) {
                        List<Claim> claims = new List<Claim>  {
                            new Claim("usuario", autentica.Apelido),
                            new Claim("token", autentica.Token)
                        };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, cookieRcLog);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await httpContext.HttpContext.Authentication.SignInAsync(cookieRcLog, claimsPrincipal);
                    }
                }
            } catch (Exception ex) {
                autentica = new AutenticaTransfer();

                autentica.Validacao = false;
                autentica.Erro = true;
                autentica.IncluirMensagem("Erro em AutenticaModel Autenticar [" + ex.Message + "]");
            } finally {
                autenticaService = null;
            }

            return autentica;
        }

        public string ObterToken() 
        {
            string token = "";

            try {
                token = httpContext.HttpContext.User.Claims.First(c => c.Type == "token").Value;
            } catch {
                token = "";
            }

            return token;
        }

        public string ObterUsuario() 
        {
            string usuario = "";

            try {
                usuario = httpContext.HttpContext.User.Claims.First(c => c.Type == "usuario").Value;
            } catch {
                usuario = "";
            }

            return usuario;
        }

        public void Sair() 
        {
            httpContext.HttpContext.Authentication.SignOutAsync(cookieRcLog);
        }
    }
}
