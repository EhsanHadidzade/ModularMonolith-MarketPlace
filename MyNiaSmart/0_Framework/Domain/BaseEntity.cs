using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public DateTime CreationDate { get; set; }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
    
}
