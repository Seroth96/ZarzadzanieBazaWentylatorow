using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarzadzanieBaza.Model;

namespace ZarzadzanieBaza.Model
{
    public class Wentylator
    {
        [Key]
        public int ID { get; set; }
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public double Power { get; set; }
        public double Pressure { get; set; }
        public double Revolution { get; set; }

        [ForeignKey("Nature")]
        public int NatureId { get; set; }
        public Nature Nature { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
