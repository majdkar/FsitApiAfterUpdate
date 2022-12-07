using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Model
{
    public class Product : BaseModel
    {
      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", Order = 1)]
        public int Id { get; set; }

        [Column(TypeName = "float")]
        public double Price { get; set; }

        // navigation properties
        public List<Category_Product> Product_Categories { get; set; }
       
    }
}
