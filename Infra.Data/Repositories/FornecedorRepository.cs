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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository( ProdutoContext context) : base(context)
        {
        }

        public Fornecedor Cadastrar(Fornecedor fornecedor)
        {
            var fornecedorDb = this.Buscar(fornecedor.Codigo);
            if (fornecedorDb == null)
            {
                this.Add(fornecedor);
            }else
            {
                fornecedorDb.AtualizarDados(fornecedor.Codigo, fornecedor.Nome);
                this.Update(fornecedorDb);
            }
            return fornecedor;
        }

        public Fornecedor Buscar(int fornecedorCodigo)
        {
            return  _dbSet.FirstOrDefaultAsync(x => x.Codigo == fornecedorCodigo).Result;
        }

        public Fornecedor Deletar(int fornecedorId)
        {
            Fornecedor fornecedor = this.Buscar(fornecedorId);
            this.Remove(fornecedor);
            return fornecedor;
        }
    }
}
