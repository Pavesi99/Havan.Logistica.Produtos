using Application.Interfaces;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace API.Controllers
{
    [Route("Produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _appService;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController( IProdutoAppService appService, ILogger<ProdutoController> logger) 
        {
            _appService = appService;
            _logger = logger;
        }

        [HttpGet, Route("{produtoId}")]
        public IActionResult Consultar([FromRoute] int produtoId)
        {
            try
            {
                return Ok(_appService.Buscar(produtoId));
            }
            catch (Exception e)
            {
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete, Route("{produtoId}")]
        public IActionResult Deletar([FromRoute] int produtoId)
        {
            try
            {
                return Ok(_appService.Deletar(produtoId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(null, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut, Route("")]
        public IActionResult Atualizar([FromBody] ProdutoDto produto)
        {
            try
            {
                return Ok(_appService.Atualizar(produto));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(null, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] ProdutoDto produto)
        {
            try
            {
                return Ok(_appService.Cadastrar(produto));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(null, null, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
