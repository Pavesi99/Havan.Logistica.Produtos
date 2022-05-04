using Application.Interfaces;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace API.Controllers
{
    [Route("Fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorAppService _appService;
        private readonly ILogger<FornecedorController> _logger;

        public FornecedorController(ILogger<FornecedorController> logger, IFornecedorAppService appService) 
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet, Route("{fornecedorId}")]
        public IActionResult Consultar([FromRoute] int fornecedorId)
        {
            try
            {
                return Ok(_appService.Buscar(fornecedorId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete, Route("{fornecedorId}")]
        public IActionResult Deletar([FromRoute] int fornecedorId)
        {
            try
            {
                return Ok(_appService.Deletar(fornecedorId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut, Route("")]
        public IActionResult Atualizar([FromBody] FornecedorDto fornecedor)
        {
            try
            {
                return Ok(_appService.Atualizar(fornecedor));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] FornecedorDto fornecedor)
        {
            try
            {
                return Ok(_appService.Cadastrar(fornecedor));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
