﻿using Domain.Interfaces.Uow;
using Havan.Logistica.Core.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Infra.Data.Uow
{
    public class UnitOfWorkBase<TContext> : IUnitOfWorkBase where TContext : DbContext
    {
        private readonly INotifier _notifier;
        private readonly TContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWorkBase(INotifier notifier, TContext context)
        {
            _notifier = notifier;
            _context = context;
        }

        public void BeginTransaction()
        {
            if (_context == null)
                throw new ArgumentException("Não é possível iniciar uma transação. O contexto está nulo.");

            _transaction = _context.Database.BeginTransaction();
        }

        public bool SaveTransactionChanges()
        {
            if (_context == null)
                throw new ArgumentException("Não é possível salvar a transação. O contexto está nulo.");
            else if (_transaction == null)
                throw new ArgumentException("Não é possível salvar a transação. A transação está nula.");
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _notifier.Notify(e.InnerException?.Message ?? e.Message);
                return false;
            }
        }

        public bool CommitTransaction()
        {
            if (_transaction == null)
                throw new ArgumentException("Não é possível finalizar a transação.A transação está nula.");
            try
            {
                _transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                _notifier.Notify(e.InnerException?.Message ?? e.Message);
                return false;
            }
        }

        public void RollBackTransaction()
        {
            if (_transaction == null)
                throw new ArgumentException("Não é possível dar rollback na transação.A transação está nula.");
            try
            {
                _transaction.Rollback();
            }
            catch (Exception e)
            {
                _notifier.Notify(e.InnerException?.Message ?? e.Message);
            }
        }

        public bool Commit()
        {
            if (_context == null)
                throw new ArgumentException("Não é possível finalizar a transação.A transação está nula.");
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                if (e.InnerException.ToString().Contains("uk_produto_codigo"))
                    _notifier.Notify("Falha ao salvar produto!. O produto pode ter sido lido por outra pessoa.Por favor, tente novamente.");
                else
                    _notifier.Notify(e.InnerException?.Message ?? e.Message);
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                    _context.Dispose();
                if (_transaction != null)
                    _transaction.Dispose();
            }
        }
    }
}
