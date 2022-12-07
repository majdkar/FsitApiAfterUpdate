using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Model
{
    public class Category  : BaseModel
    {
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", Order =1)]
        public int Id { get; set; }


        // navigation properties
        public List<Category_Product> Product_Categories { get; set; }
    }
}