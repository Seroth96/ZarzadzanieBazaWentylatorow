using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieBaza.Model
{
    public class Coefficient
    {
        [Key]
        public int ID { get; set; }

        public int Level { get; set; }

        public double Value { get; set; }
        public bool IsArchived { get; set; } = false;

        public Wentylator Wentylator { get; set; }
    }
}
