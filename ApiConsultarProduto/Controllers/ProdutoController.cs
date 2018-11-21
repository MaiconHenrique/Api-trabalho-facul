using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConsultarProduto.Context;
using ApiConsultarProduto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsultarProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly ApiConsultarProdutoContext _produtoContext;

        public ProdutoController(ApiConsultarProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_produtoContext.Produtos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _produtoContext.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null) return NoContent();

            return Ok(produto);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Post([FromBody] Produto produto)
        {
            _produtoContext.Produtos.Add(produto);
            _produtoContext.SaveChanges();
            return Ok(_produtoContext.Produtos.ToList());

        }

        [HttpGet]
        [Route("CodigoBarra/{codigo?}")]
        public IActionResult Get(string codigo)
        {
            var produto = _produtoContext.Produtos.FirstOrDefault(x => x.CodigoDeBarras.Equals(codigo));

            if (produto == null) return NoContent();

            return Ok(produto);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _produtoContext.Produtos.FirstOrDefault(x => x.Id == id);

            _produtoContext.Produtos.Remove(produto);
            _produtoContext.SaveChanges();

            return Ok(_produtoContext.Produtos.ToList());
        }

        [HttpDelete]
        [Route("CodigoBarra/{codigo?}")]
        public IActionResult DeleteByCodigo(string codigo)
        {
            var produto = _produtoContext.Produtos.FirstOrDefault(x => x.CodigoDeBarras.Equals(codigo));

            _produtoContext.Produtos.Remove(produto);
            _produtoContext.SaveChanges();

            return Ok(_produtoContext.Produtos.ToList());
        }

        [HttpPost]
        [Route("EditarProduto")]
        public ActionResult EditarLivro([FromBody]Produto produto)
        {
            _produtoContext.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _produtoContext.SaveChanges();

            return Ok(_produtoContext.Produtos.ToList());
        }
    }
}