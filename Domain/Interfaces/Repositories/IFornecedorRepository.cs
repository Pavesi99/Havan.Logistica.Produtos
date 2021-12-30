using Domain.Enum;
using Domain.Models;
using Havan.Logistica.Core.Repository;
using Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.NomeDaBase
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Fornecedor Cadastrar(Fornecedor produto);
        Fornecedor Buscar(int categoriaId);
        Fornecedor Deletar(int categoriaId);
    }
}
