using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nile.Data;
using Nile.Data.IO;
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

            _database = new FileProductDatabase("products.csv");

            //_database.Seed();

            RefreshUI();

        }

        private void RefreshUI()
        {
            var products = _database.GetAll();

            //bind to grid
            productBindingSource.DataSource = Enumerable.ToList(products);
        }


        private Product GetSelectedProduct()
        {
            if (dataGridView1.SelectedRows.Count > 0)
                return dataGridView1.SelectedRows[0].DataBoundItem as Product;

            return null;
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
            RefreshUI();
           
        }


        private void OnExit( object sender, EventArgs e )
        {
            if(ShowConfirmation("Are you sure?", "Quit"))
                Close();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;


            var form = new ProductDetailForm(product);
            var result = form.ShowDialog(this);
            //modal form

            if (result != DialogResult.OK)
                return;

            form.Product.Id = product.Id;
            //add product
            _database.Update(form.Product, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);
            RefreshUI();
        }

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;
            
            if (!ShowConfirmation("Are you sure?", "Remove product"))
                return;

            _database.Remove(product.Id);
            RefreshUI();
        }

        private void OnAbout( object sender, EventArgs e )
        {

        }

        private bool ShowConfirmation( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private IProductDatabase _database;
    }
}
