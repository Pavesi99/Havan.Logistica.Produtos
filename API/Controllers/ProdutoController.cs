using Application.Interfaces;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;
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

        public ProdutoController( IProdutoAppService appService) 
        {
            _appService = appService;
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
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
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
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }

        
    }
}
