using Domain.Enum;
using Domain.Models;
using Havan.Logistica.Core.Repository;
using Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.NomeDaBase
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto Cadastrar(Produto produto);
        Produto Buscar(int produtoId);
        Produto Deletar(int produtoId);
    }
}
