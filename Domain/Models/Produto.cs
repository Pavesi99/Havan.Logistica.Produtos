namespace Domain.Models
{
    public class Produto : Entidade<int>
    {
        protected Produto() { }
        public void AtualizarDados(int codigo, string descricao, Categoria categoria, int tipo, int precoCusto, int precoVenda, Fornecedor fornecedor)
        {
            Categoria.AtualizarDados(categoria.Codigo,categoria.Nome);
            Fornecedor.AtualizarDados(fornecedor.Codigo, fornecedor.Nome);

            Descricao = descricao;
            Tipo = tipo;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }

        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        public int Tipo { get; private set; }
        public int PrecoCusto { get; private set; }
        public int PrecoVenda { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public int FornecedorId { get; private set; }


    }
}
