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
    [Route("Fornecedor")]
    [ApiController]
    public class FornecedorController : MainController
    {
        private readonly IFornecedorAppService _appService;

        public FornecedorController(INotifier notifier, IFornecedorAppService appService) : base(notifier)
        {
            _appService = appService;
        }

        [HttpGet, Route("{fornecedorId}")]
        public IActionResult Consultar([FromRoute] int fornecedorId)
        {
            try
            {
                return Response(_appService.Buscar(fornecedorId));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }

        [HttpDelete, Route("{fornecedorId}")]
        public IActionResult Deletar([FromRoute] int fornecedorId)
        {
            try
            {
                return Response(_appService.Deletar(fornecedorId));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }


        [HttpPost, Route("")]
        public IActionResult Cadastrar([FromBody] FornecedorDto fornecedor)
        {
            try
            {
                return Response(_appService.Cadastrar(fornecedor));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }
    }
}
