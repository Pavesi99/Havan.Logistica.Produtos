using Application.Interfaces;
using AutoMapper;
using Domain.Enum;
using Domain.Interfaces.Produto;
using Domain.Interfaces.Uow;
using Domain.Models;
using Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FornecedorAppService(IFornecedorRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }

        public Fornecedor Atualizar(FornecedorDto fornecedorDto)
        {
            Fornecedor fornecedor = _mapper.Map<FornecedorDto, Fornecedor>(fornecedorDto);
            fornecedor = _repository.Atualizar(fornecedor);
            _uow.ProdutoUnitOfWork.Commit();
            return fornecedor;
        }

        public Fornecedor Buscar(int fornecedorId)
        {
            return _repository.Buscar(fornecedorId);
        }

        public Fornecedor Cadastrar(FornecedorDto fornecedorDto)
        {
            Fornecedor fornecedor = _mapper.Map<FornecedorDto, Fornecedor>(fornecedorDto);
            fornecedor =_repository.Cadastrar(fornecedor);
            _uow.ProdutoUnitOfWork.Commit();
            return fornecedor;
        }

        public Fornecedor Deletar(int fornecedorId)
        {
            var fornecedor = _repository.Deletar(fornecedorId);
            _uow.ProdutoUnitOfWork.Commit();
            return fornecedor;
        }
    }
}
