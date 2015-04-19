using NorthWind.Entity;
using NorthWind.Win.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWind.Win
{
    public partial class frmDocumento : Form
    {
        public frmDocumento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton Seleccionar Cliente
            frmCliente oFrmCliente = new frmCliente();
            oFrmCliente.onClienteSeleccionado += new EventHandler<TbClienteBE>(
                oFrmCliente_OnClienteSeleccionado);
            oFrmCliente.Show();
        }

        TbClienteBE otmpCliente;
        TbProductoBE otmpProducto;
        ItemBE oItemBE;
        DocumentoBL oDocumentoBL;
        List<ItemBE> Lista = new List<ItemBE>();

        void oFrmCliente_OnClienteSeleccionado(object sender, TbClienteBE e)
        {
            txtcliente.Text = e.Nombre;
            txtruc.Text = e.Ruc;
            otmpCliente = e;
        }
        private void oFrmProducto_OnProductoSeleccionado(object sender, TbProductoBE e)
        {

            txtproducto.Text = e.Descripcion;
            txtprecio.Text = e.Precio.ToString();
            otmpProducto = e; 

        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmProducto oFrmProducto = new frmProducto();
            oFrmProducto.onProductoSeleccionado += new System.EventHandler<TbProductoBE>(oFrmProducto_OnProductoSeleccionado);

            oFrmProducto.Show();
        }

        DocumentoBL oFacturaBL = new DocumentoBL();
        private void button3_Click(object sender, EventArgs e)
        {

            int codprodu = 0;
            int dgCantidad = 0;
          //Boton Agregar Factura 
            if (txtcantidad.Text == "" || txtcantidad.Text == "0") 
            {
                MessageBox.Show("Ingresar Cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                if (dataGridView1.Rows.Count > 0 )
                { 
                    for (int i  = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int row = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value); row == Convert.ToInt32(otmpProducto.CodProducto); row++) 
                        { 
                            dgCantidad = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                            codprodu = row;
                            if (codprodu == Convert.ToInt32(otmpProducto.CodProducto))
                            {
                                dgCantidad = dgCantidad + Convert.ToInt32(txtcantidad.Text);
                                oFacturaBL.modCantidad(dgCantidad,codprodu.ToString());
                                CargarGrilla();  
                            }
                        }
                    }   
                }
                if (codprodu != Convert.ToInt32(otmpProducto.CodProducto))
                {
                    oFacturaBL.AgregarDetalle(new ItemBE()
                    {
                        Cantidad = Convert.ToInt32(txtcantidad.Text),
                        Precio = Convert.ToDecimal(txtprecio.Text),
                        Producto = otmpProducto,
                                    
                    });

                    CargarGrilla();
                }
               
            }
            

        }
        public void CargarGrilla() 
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = oFacturaBL.GetDetalle();
            txtigv.Text = oFacturaBL.IGV.ToString();
            txtsubtotal.Text = oFacturaBL.SubTotal.ToString();
            txttotal.Text = oFacturaBL.Total.ToString();
        
        }
        private void frmDocumento_Load(object sender, EventArgs e)
        {

        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmComprobante oFrmComprobante = new FrmComprobante();
            
            oFrmComprobante.Show();
        }
    }
}
