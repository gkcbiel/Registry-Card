using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cards.Models;
using Cards.Repositories;
using Cards.Services;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Cards.Enums;
using Cards.Interfaces;
using Cards.Data;

namespace Cards.Controllers
{
    [Route("v1/account")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogService _logService;

        public AuthenticationController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate(
            [FromServices] DataContext context, 
            [FromBody] User model)
        {
            string token = string.Empty; 
            try
            {
                var user = UserRepository.Get(model.Username, model.Password);

                if (user == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                token = TokenService.GenerateToken(user);
                user.Password = "";

                return new
                {
                    user = user,
                    token = token
                };
            }
            catch (Exception e)
            {
                return BadRequest(error: $"erro tratado: {e.Message}");
            }
            finally
            {
                _logService.AddLog(context, JsonConvert.SerializeObject(model), token, (int)CardEnum.OperationType.Authenticate);
            }
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}";

    }
}

