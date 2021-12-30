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
    [Route("Categoria")]
    [ApiController]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaAppService _appService;

        public CategoriaController(INotifier notifier, ICategoriaAppService appService) : base(notifier)
        {
            _appService = appService;
        }

        [HttpGet, Route("{categoriaId}")]
        public IActionResult Consultar([FromRoute] int categoriaId)
        {
            try
            {
                return Response(_appService.Buscar(categoriaId));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }

        [HttpDelete, Route("{categoriaId}")]
        public IActionResult Deletar([FromRoute] int categoriaId)
        {
            try
            {
                return Response(_appService.Deletar(categoriaId));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }


        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] CategoriaDto categoria)
        {
            try
            {
                return Response(_appService.Cadastrar(categoria));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }
    }
}
