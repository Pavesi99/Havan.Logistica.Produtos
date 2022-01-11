using Application.Interfaces;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace API.Controllers
{
    [Route("Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _appService;
        private readonly ILogger<CategoriaController> _logger;
        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaAppService appService) 
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet, Route("{categoriaId}")]
        public IActionResult Consultar([FromRoute] int categoriaId)
        {
            try
            {
                return Ok(_appService.Buscar(categoriaId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(null,null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete, Route("{categoriaId}")]
        public IActionResult Deletar([FromRoute] int categoriaId)
        {
            try
            {
                return Ok(_appService.Deletar(categoriaId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(null, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut, Route("")]
        public IActionResult Atualiziar([FromBody] CategoriaDto categoria)
        {
            try
            {
                return Ok(_appService.Atualizar(categoria));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(null, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] CategoriaDto categoria)
        {
            try
            {
                return Ok(_appService.Cadastrar(categoria));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(null, null, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
