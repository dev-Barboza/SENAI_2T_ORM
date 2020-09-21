using EntityFramework.Context;
using EntityFramework.Domains;
using EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //nova formula ,porem indiferente 
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

       /// <summary>
       /// Adiciona um produto
       /// </summary>
       /// <param name="produto">Objeto do tipo produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //adiciona um objeto , pode se acionar mais de uma vez
                _ctx.Produtos.Add(produto);


                //salvar no db
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">id do produto </param>
        public void Remover(Guid id)
        {
            try
            {
                Produto produtoTemp = BuscarPorId(id);
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado ");

                _ctx.Produtos.Remove(produtoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       /// <summary>
       /// Edita um produto
       /// </summary>
       /// <param name="produto">produto para ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                Produto produtoTemp = BuscarPorId(produto.Id);
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado ");

                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                _ctx.Produtos.Update(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produto por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Retorna lista </returns>
        public Produto BiscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Find(nome);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produto por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna lista do produto</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return  _ctx.Produtos.FirstOrDefault(c => c.Id == id || c.Nome == "produto");
                return _ctx.Produtos.Find(id);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        
        /// <summary>
        /// Lista Todos os produtosjá cadastrados 
        /// </summary>
        /// <returns>Retorna uma lista de Produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();  
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }

        
    }
}
