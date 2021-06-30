using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAcalisma2
{
    public class Kisi
    {
        public Kisi() { }
        public Kisi(int id, string ad)
        {
            Id = id;
            Ad = ad;
        }
        public int Id { get; set; }
        public string Ad { get; set; }

        public override string ToString()
        {
            return Ad;
        }

    }
}
