using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Services.Api.MessageHandler;
using System;

namespace Api.Configurations
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                next(app);
                app.ApplicationServices.CreateScope().ServiceProvider.GetService<EntregaMessageHandler>().IniciarReceiver();
                app.ApplicationServices.CreateScope().ServiceProvider.GetService<MovimentacaoMessageHandler>().IniciarReceiver();
                app.ApplicationServices.CreateScope().ServiceProvider.GetService<EntregaInfoMessageHandler>().IniciarReceiver();
                app.ApplicationServices.CreateScope().ServiceProvider.GetService<IIntegracaoAppService>().EnviarNovosItens();
                app.ApplicationServices.CreateScope().ServiceProvider.GetService<ProcessamentoIntegracao>().Iniciar();
            };
        }
    }
}