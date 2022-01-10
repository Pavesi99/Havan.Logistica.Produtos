using Domain.Enum;
using Domain.Models;

namespace Domain.Interfaces.NomeDaBase
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Fornecedor Cadastrar(Fornecedor produto);
        Fornecedor Buscar(int categoriaId);
        Fornecedor Deletar(int categoriaId);
    }
}
