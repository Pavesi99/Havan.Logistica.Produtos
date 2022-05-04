using Application.Interfaces;
using AutoMapper;
using Domain.Enum;
using Domain.Interfaces.Integration;
using Domain.Interfaces.Produto;
using Domain.Interfaces.Uow;
using Domain.Message;
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
        private readonly IProdutoMessageHandler _produtoMessageHandler;

        public ProdutoAppService(IProdutoRepository repository, IMapper mapper, IUnitOfWork uow, IProdutoMessageHandler produtoMessageHandler)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
            _produtoMessageHandler = produtoMessageHandler;
        }

        private void IntegrarProdutoCatalogo(Produto produto)
        {
            if (produto.Tipo == (int)TipoProduto.Acabado)
                _produtoMessageHandler.Publish(_mapper.Map<Produto, CatalogoProdutosMessage>(produto));
        }

        public Produto Buscar(int fornecedorId)
        {
            return _repository.Buscar(fornecedorId);
        }

        public Produto Cadastrar(ProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<ProdutoDto, Produto>(produtoDto);

            var produtoDb = _repository.Buscar(produto.Codigo);
            if (produtoDb != null)
            {
                throw new Exception("Não é possivel cadastrar o produto pois ele já existe.");
            }

            produto = _repository.Cadastrar(produto);
            this.IntegrarProdutoCatalogo(produto);
            _uow.ProdutoUnitOfWork.Commit();

            return produto;
        }

        public Produto Deletar(int produtoId)
        {
            var produto = _repository.Deletar(produtoId);
            _uow.ProdutoUnitOfWork.Commit();
            return produto;
        }

        public Produto Atualizar(ProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<ProdutoDto, Produto>(produtoDto);
            var produtoDb = _repository.Buscar(produto.Codigo);

            if (produtoDb == null)
            {
                 throw new Exception("Não é possivel atualizar o produto pois ele não existe.");
            }

            produtoDb.AtualizarDados(produto.Codigo, produto.Descricao, produto.Categoria, produto.Tipo, produto.PrecoCusto, produto.PrecoVenda, produto.Fornecedor);
            produto = _repository.Atualizar(produtoDb);
            this.IntegrarProdutoCatalogo(produto);
            _uow.ProdutoUnitOfWork.Commit();

            return produto;
        }
    }
}
