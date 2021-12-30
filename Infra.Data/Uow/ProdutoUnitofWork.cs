using Domain.Interfaces.Uow;
using Havan.Logistica.Core.Notifications;
using Infra.Data.Context;

namespace Infra.Data.Uow
{
    public class ProdutoUnitOfWork : UnitOfWorkBase<ProdutoContext>, IProdutoUnitOfWork
    {
        public ProdutoUnitOfWork(INotifier notifier, ProdutoContext context) : base(notifier, context)
        {
        }
    }
}
