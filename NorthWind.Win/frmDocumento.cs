using NorthWind.Entity;
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

        private void button3_Click(object sender, EventArgs e)
        {
            //string cliente;
            //string ruc;
            //int Cantidad;
            //decimal precio;
            //decimal pfinal;
            //cliente = txtcliente.Text;
            //ruc = txtruc.Text;
            //Cantidad = int.Parse(txtcantidad.Text);
            //precio = decimal.Parse(txtprecio.Text);
            //pfinal = precio * Cantidad;

        }
    }
}
