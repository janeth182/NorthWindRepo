﻿using NorthWind.Entity;
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
    
    public partial class frmProducto : Form
    {
        List<TbProductoBE> Lista = new List<TbProductoBE>();
        public event EventHandler<TbProductoBE> onProductoSeleccionado;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            Lista = TbProductoBE.SelectAll();
            this.TbProductobindingSource.DataSource = Lista;
            this.dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

        }
        private void AgregarProductoFactura()
        {
            int i = dataGridView1.CurrentRow.Index;
            string codigoProducto = dataGridView1.Rows[i].Cells[0].Value.ToString();
            TbProductoBE oTbProductosBE = (from item in Lista.ToArray()
                                            where item.CodProducto == codigoProducto
                                            select item).Single();
            onProductoSeleccionado(new object(), oTbProductosBE);
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProductoFactura();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                AgregarProductoFactura();
            }
        }
    }
}
