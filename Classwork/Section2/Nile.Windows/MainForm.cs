using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            var product = new Product();
            product.Name = "Product A";
            product.Price = 50;
            product.IsDiscontinued = true;

            var price2 = product.ActualPrice;


            var productB = new Product();
            productB.Name = "whatever2";
            productB.Description = product.Description;
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var form = new ProductDetailForm("Add Product");
            //form.Text = "Add Product";
            //modal form
            if (form.ShowDialog() != DialogResult.OK)
                return;
            //add product
            _product = form.Product;
        }


        private void OnExit( object sender, EventArgs e )
        {
            if(ShowConfirmation("Are you sure?", "Quit"))
                Close();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            if (_product == null)
                return;

            var form = new ProductDetailForm("Edit Product");
           //form.Text = "Edit Product";
            form.Product = _product;
            //modal form
            if (form.ShowDialog() != DialogResult.OK)
                return;
            //add product
            _product = form.Product;
        }

        private void OnProductDelete( object sender, EventArgs e )
        {
            if (ShowConfirmation("Are you sure?", "Remove product"))
                _product = null;
        }

        private void OnAbout( object sender, EventArgs e )
        {

        }

        private bool ShowConfirmation( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private Product _product;
    }
}
