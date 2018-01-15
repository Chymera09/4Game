using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Game
{
    class FieldData
    {
        public byte Row { get; set; }
        public byte Column { get; set; }
        public byte Value { get; set; }
        public string Color { get; set; }

        public FieldData() { }
    }
}
