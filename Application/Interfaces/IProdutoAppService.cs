using Domain.Enum;
using Domain.Models;
using Infra.CrossCutting.Dto;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IProdutoAppService
    {
        Produto Cadastrar(ProdutoDto produto);
        Produto Buscar(int fornecedorId);
        Produto Deletar(int fornecedorId);
    }
}
