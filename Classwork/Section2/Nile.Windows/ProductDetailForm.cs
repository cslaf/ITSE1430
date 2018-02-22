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
    public partial class ProductDetailForm : Form
    {
        public ProductDetailForm()
        {
            InitializeComponent();
        }

        public ProductDetailForm( string title) 
        {
            InitializeComponent();

            Text = title;
        }
        public Product Product { get; set; }

        protected override void OnLoad( EventArgs e )
        {


            base.OnLoad(e);

            if (Product != null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _chkDiscontinued.Checked = Product.IsDiscontinued;
            };

        }
        private void OnCancel( object sender, EventArgs e )
        {
        }

        private void OnSave( object sender, EventArgs e )
        {
            Product product = new Product();
            product.Name = _txtName.Text;
            product.Description = _txtDescription.Text;
            product.Price = ConvertToPrice(_txtPrice);
            product.IsDiscontinued = _chkDiscontinued.Checked;

            Product = product;

            DialogResult = DialogResult.OK;
            Close();

        }

        private decimal ConvertToPrice(TextBox control )
        {
            if (Decimal.TryParse(control.Text, out var price))
                return price;

            return -1;
        }
    }
}
