using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrudMercado.Model.Entities
{
    public class FornecedorEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<ProdutoEntity> Produtos { get; set; }



        public List<string> ErrosFornecedor = new List<string>();
        //Validar informações
        public bool FornecedorValido()
        {
            
            NomeValido();
            CpfValido();
            if (ErrosFornecedor.Count == 0)
                return true;
            else
                return false;
        }



        private bool NomeValido()
        {
            if (Nome == null)
            {
                ErrosFornecedor.Add("Nome é obrigatório.");
                return false;
            }
            else if (Nome.Length <= 2 || Nome.Length > 150)
            {
                ErrosFornecedor.Add("Nome deve conter entre 3 e 150 caracteres.");
                return false;
            }
            else
                return true;
        }
        private bool CpfValido()
        {
            if (Cpf == null)
            {
                ErrosFornecedor.Add("Cpf é obrigatório.");
                return false;
            }
            else if (Cpf.Length != 14)
            {
                ErrosFornecedor.Add("Cpf deve conter 14 digitos.");
                return false;
            }
            else
                return true;
        }
    }
}
