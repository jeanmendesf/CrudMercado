using CrudMercado.Business;
using CrudMercado.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudMercado.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : Controller
    {
        readonly FornecedorBusiness _fornecedorBusiness;
        public FornecedorController()
        {
            _fornecedorBusiness = new FornecedorBusiness();
        }



        [HttpPost]
        [Route("Adicionar")]
        public ActionResult AdicionarFornecedor(FornecedorEntity fornecedor)
        {
            bool gravou = _fornecedorBusiness.AdicionarFornecedor(fornecedor);
            if (gravou == true)
                return Ok(fornecedor);
            else
                return BadRequest(fornecedor.ErrosFornecedor);
        }



        [HttpPut]
        [Route("Atualizar")]
        public ActionResult AtualizarFornecedor(FornecedorEntity novoFornecedor)
        {
            //Para não ter que reescrever todos os dados, a pagina de atualização deve vir
            //com as informações que o usuário ja cadastrou anteriormente
            bool atualizou = _fornecedorBusiness.AtualizarFornecedor(novoFornecedor);
            if (atualizou == true)
                return Ok(novoFornecedor);
            else
                return BadRequest(novoFornecedor.ErrosFornecedor);

        }        
        


        [HttpGet]
        [Route("Obter")]
        public ActionResult ObterTodosFornecedores()
        {
            IEnumerable<FornecedorEntity> fornecedores;
            fornecedores = _fornecedorBusiness.ObterTodosFornecedores();
            return Ok(fornecedores);
        }



        [HttpGet]
        [Route("Obter/{id?}")]
        public ActionResult ObterFornecedorPorID(int? id)
        {
            FornecedorEntity fornecedor = new FornecedorEntity();
            fornecedor = _fornecedorBusiness.ObterFornecedorPorID(id);
            return Ok(fornecedor);
        }



        [HttpDelete]
        [Route("Delete/{id?}")]
        public ActionResult DeletarFornecedor(int? id)
        {
            if (id == null)
                return BadRequest();
            else
            {
                _fornecedorBusiness.DeletarFornecedor(id);
                return Ok();
            }
        }
    }
}
