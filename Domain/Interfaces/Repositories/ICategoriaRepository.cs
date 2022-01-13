using Domain.Models;

namespace Domain.Interfaces.Produto
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Categoria Cadastrar(Categoria produto);
        Categoria Atualizar(Categoria produto);
        Categoria Buscar(int categoriaCodigo);
        Categoria Deletar(int categoriaCodigo);
    }
}
