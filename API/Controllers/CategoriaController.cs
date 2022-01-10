using Application.Interfaces;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace API.Controllers
{
    [Route("Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _appService;

        public CategoriaController( ICategoriaAppService appService) 
        {
            _appService = appService;
        }

        [HttpGet, Route("{categoriaId}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categoria))]
        public IActionResult Consultar([FromRoute] int categoriaId)
        {
            try
            {
                return Ok(_appService.Buscar(categoriaId));
            }
            catch (Exception e)
            {
                return Problem(e.InnerException?.Message ?? e.Message,null, (int)HttpStatusCode.InternalServerError);
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
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
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
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
