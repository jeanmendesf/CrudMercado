using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMercado.Business;
using CrudMercado.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudMercado.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        readonly ProdutoBusiness _produtoBusiness;
        public ProdutoController()
        {
            _produtoBusiness = new ProdutoBusiness();
        }



        public ActionResult Post(ProdutoEntity produto)
        {
            bool gravou = _produtoBusiness.AdicionarProduto(produto);
            if (gravou == true)
                return Ok();
            else
                return BadRequest(produto.ErrosProdutos);
        }
    }
}
