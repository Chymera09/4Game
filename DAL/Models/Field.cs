using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Field
    {
        public int OID { get; set; }

        public byte Row { get; set; }

        public byte Column { get; set; }

        public byte Value { get; set; }

        public string Color { get; set; }

        public virtual Game Game { get; set; }
    }
}
