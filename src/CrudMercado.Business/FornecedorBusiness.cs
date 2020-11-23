using CrudMercado.Data.DAL.DAL;
using CrudMercado.Model.Entities;
using System.Collections.Generic;

namespace CrudMercado.Business
{
    public class FornecedorBusiness
    {
        private readonly FornecedorDAL _fornecedorDAL;
        public FornecedorBusiness()
        {
            _fornecedorDAL = new FornecedorDAL();
        }



        public bool AdicionarFornecedor(FornecedorEntity fornecedor)
        {
            if (fornecedor.FornecedorValido() == false)
                return false;
            else
            {
                _fornecedorDAL.AddFornecedor(fornecedor);
                return true;
            }
        }



        public bool AtualizarFornecedor(FornecedorEntity novoFornecedor)
        {
            if (novoFornecedor.FornecedorValido() == false)
                return false;
            else
            {
                _fornecedorDAL.UpdateFornecedor(novoFornecedor);
                return true;
            }
        }



        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            IEnumerable<FornecedorEntity> fornecedores;

            fornecedores = _fornecedorDAL.GetAllFornecedores();
            return fornecedores;
        }



        public FornecedorEntity ObterFornecedorPorID(int? id)
        {            
            FornecedorEntity fornecedor = _fornecedorDAL.GetFornecedor(id);
            return fornecedor;
        }



        public void DeletarFornecedor(int? id)
        {
            _fornecedorDAL.DeleteFornecedor(id);
        }
    }
}
