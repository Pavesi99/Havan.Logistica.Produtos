using Domain.Enum;
using Domain.Models;
using Infra.CrossCutting.Dto;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICategoriaAppService
    {
        Categoria Cadastrar(CategoriaDto categoria);
        Categoria Atualizar(CategoriaDto categoria);
        Categoria Buscar(int categoriaId);
        Categoria Deletar(int categoriaId);
    }
}
