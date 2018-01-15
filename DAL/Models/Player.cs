using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Player
    {
        public int OID { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Score { get; set; }

        [Required]
        public string Color { get; set; }

        public virtual Environment Environment { get; set; }

        public virtual Game Game { get; set; }
    }
}
