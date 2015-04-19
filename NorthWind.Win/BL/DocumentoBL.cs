using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Win.BL
{
    public class DocumentoBL
    {
        public decimal SubTotal { get; set; }
        public decimal IGV 
        {
            get { return SubTotal * (decimal)0.18; }
        }
        public decimal Total 
        {
            get { return SubTotal + IGV; }
        }
        public decimal pCodProducto { get; set; }

        public List<ItemBE> oDetalle = new List<ItemBE>();
        
        public void AgregarDetalle(ItemBE oItem) 
        {
                SubTotal += oItem.Total;
                oItem.Item = oDetalle.Count + 1;
                oDetalle.Add(oItem);
            
        }
        public void modCantidad(int cantidad,string codproducto)
        {
            ItemBE oItemBE = new ItemBE(); 
            var item = (from p in oDetalle  where p.CodProducto == codproducto select p).Single();
            item.Cantidad = cantidad;
            
        }
       
        public List<ItemBE> GetDetalle() {

            var total = (from prod in oDetalle select (long)prod.Total).Sum();
            SubTotal = total;
            return oDetalle;
        }
    }
}
