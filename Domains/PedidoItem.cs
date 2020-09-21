using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Domains
{
<<<<<<< HEAD
    public class PedidoItem : BaseDomain
    {
        
=======
    public class PedidoItem
    {
        [Key]
        public Guid Id { get; set; }
>>>>>>> c17d00adcd70dce96b41a01daf073314bbed5b89
        public Guid IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        public Guid IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

<<<<<<< HEAD
     
=======
        public PedidoItem()
        {
            Id = Guid.NewGuid();
        }

>>>>>>> c17d00adcd70dce96b41a01daf073314bbed5b89
    }
}
