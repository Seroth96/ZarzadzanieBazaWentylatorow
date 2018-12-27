using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieBaza.Model
{
    public class Nature
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public ICollection<Wentylator> Wentylatory { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
