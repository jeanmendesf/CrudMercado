using CrudMercado.Business;
using CrudMercado.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudMercado.MVC.Controllers
{
    [Route("Fornecedor")]
    public class FornecedorMVCController : Controller
    {
        readonly FornecedorBusiness _fornecedorBusiness;
        public FornecedorMVCController()
        {
            _fornecedorBusiness = new FornecedorBusiness();
        }

        /*public async Task<IActionResult> Index()
        {
            IEnumerable<FornecedorEntity> fornecedores = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44339/api/fornecedor");
                //Http Get
                var result = await client.GetAsync("/obter");
                if (result.IsSuccessStatusCode)
                {
                    fornecedores = await result.Content.ReadAsAsync<IList<FornecedorEntity>>();
                }
                else
                {
                    fornecedores = Enumerable.Empty<FornecedorEntity>();
                    ModelState.AddModelError(string.Empty, "Nenhum fornecedor encontrado.");
                }
                return View(fornecedores);
            }
        }*/


        [HttpGet]
        [Route("Obter")]
        public async Task<IActionResult> ObterTodosFornecedores()
        {
            IEnumerable<FornecedorEntity> fornecedores;
            fornecedores = _fornecedorBusiness.ObterTodosFornecedores();

            return View(fornecedores);
        }



        [HttpGet]
        [Route("Obter/{id?}")]
        public async Task<IActionResult> ObterFornecedorPorId(int? id)
        {
            FornecedorEntity fornecedor = new FornecedorEntity();
            fornecedor = _fornecedorBusiness.ObterFornecedorPorID(id);
            return View(fornecedor);
        }



        [HttpGet]
        [Route("Adicionar")]
        public async Task<IActionResult> AdicionarFornecedor()
        {
            var fornecedor = new FornecedorEntity();
            return View(fornecedor);
        }
        [Route("Adicionar")]
        [HttpPost]
        public async Task<IActionResult> AdicionarFornecedor(FornecedorEntity fornecedor)
        {
            bool gravou = _fornecedorBusiness.AdicionarFornecedor(fornecedor);
            if (gravou == true)
            return RedirectToAction("Obter", "Fornecedor");
            else
                return View(fornecedor.ErrosFornecedor);
        }




        [HttpGet]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> AtualizarFornecedor(int? id)
        {
            FornecedorEntity fornecedor = _fornecedorBusiness.ObterFornecedorPorID(id);
            return View(fornecedor);
        }
        [HttpPost]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> AtualizarFornecedor(FornecedorEntity fornecedor)
        {
            bool atualizou = _fornecedorBusiness.AtualizarFornecedor(fornecedor);
            if (atualizou == true)
            return RedirectToAction("Obter", "Fornecedor");

            else
                return View(fornecedor.ErrosFornecedor);
        }




        [HttpGet]
        [Route("Deletar/{id?}")]
        public async Task<IActionResult> DeletarFornecedor(int? id)
        {
            FornecedorEntity fornecedor = _fornecedorBusiness.ObterFornecedorPorID(id);

            if (id== null)
                return View("NotFound");

            if (fornecedor == null)
                return NotFound();
            else
                return View(fornecedor);
        }
        [HttpPost]
        [Route("Deletar/{id?}")]
        public async Task<IActionResult> DeletarFornecedor(FornecedorEntity fornecedor)
        {
            if (fornecedor == null)
                return View("Fornecedor não encontrado.");
            else
            {
                _fornecedorBusiness.DeletarFornecedor(fornecedor.Id);
                return RedirectToAction("Obter", "Fornecedor");
            }
        }
    }
}
