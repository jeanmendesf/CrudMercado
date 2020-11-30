using CrudMercado.Data.DAL.DAL;
using CrudMercado.Model.Entities;
using System.Collections.Generic;

namespace CrudMercado.Business
{
    public class ProdutoBusiness
    {
        private readonly ProdutoDAL _produtoDAL;
        public ProdutoBusiness()
        {
            _produtoDAL = new ProdutoDAL();
        }



        public bool AdicionarProduto(ProdutoEntity produto)
        {
            if (produto.ValidarProduto() == false)
                return false;
            else
                _produtoDAL.AddProduto(produto);
            return true;
        }



        public IEnumerable<ProdutoEntity> ObterTodosProdutos()
        {
            IEnumerable<ProdutoEntity> produtos;
            produtos = _produtoDAL.GetAllProdutos();
            return produtos;
        }



        public ProdutoEntity ObterProdutoPorId(int? id)
        {
            ProdutoEntity produto = _produtoDAL.GetProduto(id);
            return produto;
        }



        public bool AtualizarProduto(ProdutoEntity produto)
        {
            if (produto.ValidarProduto() == false)
                return false;
            else
            {
                _produtoDAL.UpdateProduto(produto);
                return true;
            }
        }



        public void DeletarProduto(int? id)
        {
            _produtoDAL.DeleteFornecedor(id);
        }



    }
}
