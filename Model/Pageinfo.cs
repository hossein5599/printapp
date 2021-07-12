using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintApp.Model
{
  public  class Pageinfo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string PageName { get; set; }

        //public byte[] Picture { get; set; }

        public string FormName { get; set; }

        public double OnePagePrice { get; set; }
    }
}
