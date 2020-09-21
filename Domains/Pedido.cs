using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Domains
{
<<<<<<< HEAD
    public class Pedido : BaseDomain
    {
        
=======
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }
>>>>>>> c17d00adcd70dce96b41a01daf073314bbed5b89
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }


<<<<<<< HEAD
       
=======
        Pedido()
        {
            Id = Guid.NewGuid();
        }
>>>>>>> c17d00adcd70dce96b41a01daf073314bbed5b89
    }
}
