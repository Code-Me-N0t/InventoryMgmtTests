using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace InventoryMgmt.Model
{
    public class Product
    {

        public int ProductID { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Name should not be empty")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public required string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage="Quantity must be greater than or equal to {1}.")]
        public required int QuantityInStock { get; set; }
        
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage="Price must be greater than or equal to {1}.")]
        public required decimal Price { get; set; }
    }
}
