using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cards.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Cards.Services;
using Cards.Interfaces;
using Newtonsoft.Json;
using Cards.Enums;

namespace Cards.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/card")]

    public class CardController : ControllerBase
    {

        private readonly IFileService _fileService;
        private readonly ILogService _logService;

        public CardController(IFileService fileService, ILogService logService)
        {
            _fileService = fileService;
            _logService = logService;
        }


        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Credit>>> Get([FromServices] DataContext context)
        {
            var credit = await context.Credit.ToListAsync();

            _logService.AddLog(context, "", JsonConvert.SerializeObject(credit), (int)CardEnum.OperationType.Get);

            return credit;
        }

        [HttpGet]
        [Route("{cardNumber}")]
        public async Task<ActionResult<Credit>> GetByCardNumber([FromServices] DataContext context, string cardNumber)
        {
            var credit = await context.Credit.FirstOrDefaultAsync(v => v.CardNumber == cardNumber);

            _logService.AddLog(context, cardNumber, JsonConvert.SerializeObject(credit), (int)CardEnum.OperationType.GetByCardNumber);

            return credit;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Credit>> Post(
            [FromServices] DataContext context,
            [FromBody] Credit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!context.Credit.Any(v => v.Id == model.Id))
                    {
                        context.Credit.Add(model);
                        await context.SaveChangesAsync();
                        return model;
                    }
                    else
                    {
                        return BadRequest(error: "Já existe um registro para este lote");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(error: $"erro tratado: {ex.Message}");
                }
                finally
                {
                    _logService.AddLog(context, JsonConvert.SerializeObject(model), JsonConvert.SerializeObject(model), (int)CardEnum.OperationType.Post);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("{method}")]
        public IActionResult Upload(
            [FromServices] DataContext context,
            IFormFile file)
        {
            List<string> fileContentList = new List<string>();
            string line;

            try
            {
                List<string> errorList = _fileService.FileValidation(file);
                
                if (errorList.Count == 0)
                {
                    using (StreamReader sr = new StreamReader(file.OpenReadStream()))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            fileContentList.Add(line);
                        }
                    }

                    return Ok(fileContentList);
                }
                else
                {
                    return BadRequest(errorList);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            finally
            {
                _logService.AddLog(context, file?.FileName, JsonConvert.SerializeObject(fileContentList), (int)CardEnum.OperationType.Upload);
            }
        }
    }
}
