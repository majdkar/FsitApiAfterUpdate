using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Model
{
    public  class Category_Product
    {
        

        [Column(TypeName = "int")]
        public int ProductId { get; set; }

        public Product product { get; set; }

        [Column(TypeName = "int")]
        public int CategoryId { get; set; }

        public Category category { get; set; }
    }
}
