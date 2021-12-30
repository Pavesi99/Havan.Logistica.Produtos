using Havan.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Fornecedor : Entity<int>
    {
        protected Fornecedor() { }
        public void AtualizarDados(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public int Codigo { get; private set; }
        public string Nome { get; private set; }

    }
}
