using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Domains;
using EntityFramework.Interfaces;
using EntityFramework.Repositories;
using EntityFramework.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        // só é feito pois esta herdado
        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                
                var produtos = _produtoRepository.Listar();

                
                if (produtos.Count == 0)
                    return NoContent();

                
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public IActionResult  Get(Guid id)
        {
            try
            {
               
                Produto produto = _produtoRepository.BuscarPorId(id);

               
                if (produto == null)
                    return NotFound();

                Moeda dolar = new Moeda();

                
                return Ok(new { 
                    produto,
                    valorDolar = produto.Preco /dolar.GetDolarValue()
                });
            }
            catch (Exception ex)
            {
                //cria o um novo obj e devolve uma mensagem de erro 
                return BadRequest(new { 
                StatusCode = 400,
                error = "Ocorreu um erro no endpoint Get/produtos, envie um email para nós"
                });
            }
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                if (produto.Imagem != null)
                {
                    var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(produto.Imagem.FileName);

                    var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

                    using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

                    produto.Imagem.CopyTo(streamImagem);

                    produto.UrlImagem = "https://localhost:44354/uploas/imagens" + nomeArquivo;
                }
               
                //Adiciona um novo produto
                _produtoRepository.Adicionar(produto);

                //Retorna mensgame se for cadstrado
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                //Define o id 
                produto.Id = id;

                _produtoRepository.Editar(produto);

                
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                var produto = _produtoRepository.BuscarPorId(id);

                //Verifica se produto existe
                //Caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso exista remove o produto
                _produtoRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
