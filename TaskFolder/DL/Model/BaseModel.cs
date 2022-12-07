using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Model
{
    public class BaseModel
    {
        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000)]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(50)"), MaxLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? CreateOfDate { get; set; }
    }
}
