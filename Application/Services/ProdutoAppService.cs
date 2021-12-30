using Application.Interfaces;
using AutoMapper;
using Domain.Enum;
using Domain.Interfaces.NomeDaBase;
using Domain.Interfaces.Uow;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Integration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;


        public ProdutoAppService(IProdutoRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }

        public Produto Buscar(int fornecedorId)
        {
            return _repository.Buscar(fornecedorId);
        }

        public Produto Cadastrar(ProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<ProdutoDto, Produto>(produtoDto);
            if (produto != null)
            {
                produto = _repository.Cadastrar(produto);

                if (produto.Tipo == (int)TipoProduto.Acabado)
                    new ProdutoMessageHandler().Publish(_mapper.Map<Produto, CatalogoProdutosMessage>(produto));

                _uow.ProdutoUnitOfWork.Commit();
            }

            return produto;
        }

        public Produto Deletar(int produtoId)
        {
            var produto = _repository.Deletar(produtoId);
            _uow.ProdutoUnitOfWork.Commit();
            return produto;
        }
    }
}
