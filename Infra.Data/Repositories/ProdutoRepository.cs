using Domain.Interfaces.Produto;
using Infra.Data.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.ItlSys
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoContext context) : base(context)
        {
        }

        public Produto Buscar(int produtoCodigo)
        {
            var produto = _dbSet.Include(x => x.Fornecedor)
                .Include(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Codigo == produtoCodigo);

            return produto.Result;
        }

        public Produto Atualizar(Produto produto)
        {
            this.Update(produto);
            return produto;
        }


        public Produto Cadastrar(Produto produto)
        {
            this.Add(produto);
            return produto;
        }

        public Produto Deletar(int produtoId)
        {
            Produto produto = this.Buscar(produtoId);
            if (produto == null)
            {
                return null;
            }

            this.Remove(produto);
            return produto;
        }
    }
}
