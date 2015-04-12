using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entity
{
    public class CabDocumentoBE
    {
        public string CodDocumento { get; set; }
        public TbClienteBE Cliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IGV { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaHora { get; set; }
        public eTipoDocumento TipoDocumento { get; set; }

       
    }
}
