using Domain.Models;

namespace Domain.Interfaces.NomeDaBase
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto Cadastrar(Produto produto);
        Produto Buscar(int produtoId);
        Produto Deletar(int produtoId);
    }
}
