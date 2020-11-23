using System;
using System.Collections.Generic;
using System.Text;

namespace CrudMercado.Model.Entities
{
    public class ProdutoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Decimal Preco { get; set; }
        public int FornecedorId { get; set; }

        public List<string> ErrosProdutos = new List<string>();

        public bool ValidarProduto()
        {
            ValidarNome();
            ValidarDescricao();
            ValidarPreco();
            if (ErrosProdutos.Count > 0)
                return false;
            else
                return true;
        }



        private bool ValidarNome()
        {
            if (Nome == null)
            {
                ErrosProdutos.Add("Nome do produto é obrigatório.");
                return false;
            }
            else if (Nome.Length < 3 || Nome.Length > 150)
            {
                ErrosProdutos.Add("Nome do produto deve ter entre 3 e 150 caracteres.");
                return false;
            }
            else
                return true;
        }
        private bool ValidarDescricao()
        {
            if (Descricao == null)
            {
                ErrosProdutos.Add("A descrição é obrigatória.");
                return false;
            }
            else if (Descricao.Length < 3 || Descricao.Length > 300)
            {
                ErrosProdutos.Add("A descrição deve conter entre 3 e 300 caracteres.");
                return false;
            }
            else
                return true;
        }
        private bool ValidarPreco()
        {
            if (Preco < 5)
            {
                ErrosProdutos.Add("O preço do produto deve ser maior ou igual a $ 5,00");
                return false;
            }
            else
                return true;
        }
    }
}
