using CrudMercado.Data.DAL.DAL;
using CrudMercado.Model.Entities;

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


        


    }
}
