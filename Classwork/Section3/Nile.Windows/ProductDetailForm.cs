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

        public ProductDetailForm(Product product ) :this("Edit Product")
        {
            Product = product;
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
            if (!ValidateChildren())
                return;

            Product product = new Product() {
            Name = _txtName.Text,
            Description = _txtDescription.Text,
            Price = ConvertToPrice(_txtPrice),
            IsDiscontinued = _chkDiscontinued.Checked,
        };
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
