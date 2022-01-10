using Domain.Enum;
using Domain.Models;
using Infra.CrossCutting.Dto;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IFornecedorAppService
    {
        Fornecedor Cadastrar(FornecedorDto fornecedor);
        Fornecedor Buscar(int fornecedorId);
        Fornecedor Deletar(int fornecedorId);
    }
}
