using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Domains
{
    public class Produto : BaseDomain
    {
        
        public string Nome { get; set; }
        public float Preco { get; set; }

        [NotMapped]
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }

        //Mais de um item= lista e um relacionamento com a tabela pedido item
        public List<PedidoItem> PedidosItens { get; set; }


    }
}
