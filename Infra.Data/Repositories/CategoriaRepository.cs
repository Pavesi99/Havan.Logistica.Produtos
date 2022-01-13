using Domain.Enum;
using Domain.Interfaces.Produto;
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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ProdutoContext context) : base(context)
        {
        }

        public Categoria Cadastrar(Categoria categoria)
        {
            this.Add(categoria);
            return categoria;
        }

        public Categoria Buscar(int CategoriaCodigo)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Codigo == CategoriaCodigo).Result;
        }

        public Categoria Deletar(int categoriaCodigo)
        {
            Categoria categoria = this.Buscar(categoriaCodigo);
            this.Remove(categoria);
            return categoria;
        }

        public Categoria Atualizar(Categoria categoria)
        {
            this.Update(categoria);
            return categoria;
        }
    }
}
