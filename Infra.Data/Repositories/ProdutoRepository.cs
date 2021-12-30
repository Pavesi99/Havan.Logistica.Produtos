using Domain.Enum;
using Domain.Interfaces.NomeDaBase;
using Infra.CrossCutting.Dto;
using Infra.Data.Config;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Infra.Data.Context;
using System.Text;
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

        public Produto Cadastrar(Produto produto)
        {
            var produtoDb = this.Buscar(produto.Codigo);
            if (produtoDb != null)
            {
                produtoDb.AtualizarDados(produto.Codigo, produto.Descricao, produto.Categoria, produto.Tipo, produto.PrecoCusto, produto.PrecoVenda, produto.Fornecedor);
                this.Update(produtoDb);
                return produtoDb;
            }

            this.Add(produto);
            return produto;
        }

        public Produto Deletar(int produtoId)
        {
            Produto produto = this.Buscar(produtoId);
            if (produto != null)
            {
                this.Remove(produtoId);
            }

            return produto;
        }
    }
}
