using AutoMapper;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Integration;

namespace Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Categoria, CategoriaMessage>();
            CreateMap<Produto, CatalogoProdutosMessage>()
                .ForMember(c => c.NomeFornecedor, opt => opt.MapFrom(p => p.Fornecedor.Nome));
        }
    }
}
