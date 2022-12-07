using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Model
{
   public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)"), MaxLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000)]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(100)"), MaxLength(100)]
        public string Email { get; set; }
    }
}
