using Domain.Models;

namespace Domain.Interfaces.Produto
{
    public interface IProdutoRepository : IRepository<Models.Produto>
    {
        Models.Produto Cadastrar(Models.Produto produto);
        Models.Produto Atualizar(Models.Produto produto);

        Models.Produto Buscar(int produtoId);
        Models.Produto Deletar(int produtoId);
    }
}
