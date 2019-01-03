using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarzadzanieBaza.Model;

namespace ZarzadzanieBaza
{
    public class WentylatorDT
    {
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Moc [W]")]
        public double Power { get; set; }
        [DisplayName("Obroty/min")]
        public double Revolution { get; set; }
        [DisplayName("Rodzaj wentylatora")]
        public Nature Nature { get; set; }
    }
}
