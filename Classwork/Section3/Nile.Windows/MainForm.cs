using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nile.Data.Memory;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            RefreshUI();
        }

        private void RefreshUI()
        {
            var products = _database.GetAll();

            //bind to grid
            dataGridView1.DataSource = products;
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var form = new ProductDetailForm("Add Product");
            //form.Text = "Add Product";
            //modal form
            if (form.ShowDialog() != DialogResult.OK)
                return;
            //add product
            _database.Add(form.Product, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);
           
        }


        private void OnExit( object sender, EventArgs e )
        {
            if(ShowConfirmation("Are you sure?", "Quit"))
                Close();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var products = _database.GetAll();
            var product = (products.Count > 0) ? products[0] : null;
            if (product == null)
                return;


            var form = new ProductDetailForm(product);
            form.Text = "Edit Product";
           //form.Text = "Edit Product";
            form.Product = product;
            //modal form
            _database.Edit(form.Product, out var message);
            if (form.ShowDialog() != DialogResult.OK)
                return;
            //add product
            product = form.Product;
        }

        private void OnProductDelete( object sender, EventArgs e )
        {
            var products = _database.GetAll();
            var product = (products.Count > 0) ? products[0] : null;
            if (product == null)
                return;
            
            if (ShowConfirmation("Are you sure?", "Remove product"))
                return;

            _database.Remove(product.Id);
        }

        private void OnAbout( object sender, EventArgs e )
        {

        }

        private bool ShowConfirmation( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private MemoryProductDatabase _database = new MemoryProductDatabase();
    }
}
