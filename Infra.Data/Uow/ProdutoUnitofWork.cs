using Domain.Interfaces.Uow;
using Infra.Data.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Uow
{
    public class ProdutoUnitOfWork : UnitOfWorkBase<ProdutoContext>, IProdutoUnitOfWork
    {
        public ProdutoUnitOfWork(ILogger<ProdutoContext> logger,ProdutoContext context) : base(logger, context)
        {
        }
    }
}
