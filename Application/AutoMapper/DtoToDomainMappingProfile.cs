using AutoMapper;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Integration;

namespace Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProdutoDto, Produto>();
            CreateMap<CategoriaDto, Categoria>();
            CreateMap<FornecedorDto, Fornecedor>();
        }
    }
}
