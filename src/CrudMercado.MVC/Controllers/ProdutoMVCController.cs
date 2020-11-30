using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMercado.Business;
using CrudMercado.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudMercado.MVC.Controllers
{
    [Route("Produto")]
    public class ProdutoMVCController : Controller
    {
        readonly ProdutoBusiness _produtoBusiness;
        public ProdutoMVCController()
        {
            _produtoBusiness = new ProdutoBusiness();
        }



        [HttpGet]
        [Route("Obter")]
        public async Task<IActionResult> ObterTodosProdutos()
        {
            IEnumerable<ProdutoEntity> produtos;
            produtos = _produtoBusiness.ObterTodosProdutos();

            return View(produtos);
        }


        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<IActionResult> ObterProdutoPorId(int? id)
        {
            ProdutoEntity produto = new ProdutoEntity();
            produto = _produtoBusiness.ObterProdutoPorId(id);
            return View(produto);
        }




        [HttpGet]
        [Route("Adicionar")]
        public async Task<IActionResult> AdicionarProduto()
        {
            var produtos = new ProdutoEntity();
            return View(produtos);
        }
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> AdicionarProduto(ProdutoEntity produto)
        {
            bool gravou = _produtoBusiness.AdicionarProduto(produto);
            if (gravou == true)
                return RedirectToAction("Obter", "Produto");
            else
                return View(produto.ErrosProdutos);
        }



        [HttpGet]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> AtualizarProduto(int? id)
        {
            ProdutoEntity produto = _produtoBusiness.ObterProdutoPorId(id);
            return View(produto);
        }
        [HttpPost]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> AtualizarProduto(ProdutoEntity produto)
        {
            bool atualizou = _produtoBusiness.AtualizarProduto(produto);
            if (atualizou == true)
                return RedirectToAction("Obter", "Produto");
            else
                return View(produto.ErrosProdutos);
        }



        [HttpGet]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarProduto(int? id)
        {
            ProdutoEntity produto = _produtoBusiness.ObterProdutoPorId(id);
            if (produto == null)
                return NotFound();
            else
                return View(produto);
        }
        [HttpPost]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarProduto(ProdutoEntity produto)
        {
            if (produto == null)
                return View("Produto não encontrado.");
            else
            {
                _produtoBusiness.DeletarProduto(produto.Id);
                return RedirectToAction("Obter", "Produto");
            }
        }





    }
}
