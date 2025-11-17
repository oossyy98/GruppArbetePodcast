using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Avsnitt
    {
        public string Titel { get; set; }
        public string? Beskrivning { get; set; }
        public DateTime? PubliceringsDatum { get; set; }
        public Avsnitt()
        {

        }
    }
}
