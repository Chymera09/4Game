using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Game
    {
        public int OID { get; set; }

        public DateTime Date { get; set; }

        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public int CurrentPlayer { get; set; }

        public bool Diagonal { get; set; }

        public bool MaxValueClick { get; set; }

        public bool HiddenFieldNumbers { get; set; }
    }
}
