using Domain.Enum;
using Domain.Models;

namespace Domain.Interfaces.Produto
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Fornecedor Cadastrar(Fornecedor produto);
        Fornecedor Atualizar(Fornecedor produto);
        Fornecedor Buscar(int categoriaId);
        Fornecedor Deletar(int categoriaId);
    }
}
