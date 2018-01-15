using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Environment
    {
        public int OID { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public int PlayerNumber { get; set; }

        //public List<string> Names { get; set; }

        //public List<string> Colors { get; set; }

        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public bool Diagonal { get; set; }

        public bool MaxValueClick { get; set; }

        public bool HiddenFieldNumbers { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
