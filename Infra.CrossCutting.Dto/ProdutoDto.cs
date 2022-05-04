using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Dto
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public CategoriaDto Categoria { get; set; }
        public int Tipo { get; set; }
        public int PrecoCusto { get; set; }
        public int PrecoVenda { get; set; }
        public FornecedorDto Fornecedor { get; set; }

    }
}
