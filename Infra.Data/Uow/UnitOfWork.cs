using Domain.Interfaces.Uow;

namespace Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProdutoUnitOfWork ProdutoUnitOfWork { get; private set; }

        public UnitOfWork( IProdutoUnitOfWork arquiteturaProdutoUnitOfWork)
        {
            ProdutoUnitOfWork = arquiteturaProdutoUnitOfWork;
        }
    }
}
