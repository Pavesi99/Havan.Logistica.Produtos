using Application.Interfaces;
using AutoMapper;
using Domain.Enum;
using Domain.Interfaces.NomeDaBase;
using Domain.Interfaces.Uow;
using Domain.Models;
using Infra.CrossCutting.Dto;

namespace Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public CategoriaAppService(ICategoriaRepository repository, IMapper mapper,  IUnitOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        public Categoria Buscar(int categoriaId)
        {
            return _repository.Buscar(categoriaId);
        }

        public Categoria Cadastrar(CategoriaDto CategoriaDto)
        {
            Categoria categoria = _mapper.Map<CategoriaDto, Categoria>(CategoriaDto);
            _repository.Cadastrar(categoria);

            _uow.ProdutoUnitOfWork.Commit();
            return categoria;
        }

        public Categoria Deletar(int categoriaId)
        {
            var categoria =  _repository.Deletar(categoriaId);
            _uow.ProdutoUnitOfWork.Commit();
            return categoria;
        }
    }
}
