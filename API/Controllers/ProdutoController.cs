using Application.Interfaces;
using Havan.Logistica.Core.Controller;
using Havan.Logistica.Core.Notifications;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("Produto")]
    [ApiController]
    public class ProdutoController : MainController
    {
        private readonly IProdutoAppService _appService;

        public ProdutoController(INotifier notifier, IProdutoAppService appService) : base(notifier)
        {
            _appService = appService;
        }

        [HttpGet, Route("{produtoId}")]
        public IActionResult Consultar([FromRoute] int produtoId)
        {
            try
            {
                return Response(_appService.Buscar(produtoId));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }

        [HttpDelete, Route("{produtoId}")]
        public IActionResult Deletar([FromRoute] int produtoId)
        {
            try
            {
                return Response(_appService.Deletar(produtoId));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }


        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] ProdutoDto produto)
        {
            try
            {
                return Response(_appService.Cadastrar(produto));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }

        
    }
}
