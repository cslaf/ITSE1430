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
        
        public Product Product { get; set; }
        private void OnCancel( object sender, EventArgs e )
        {
        }

        private void OnSave( object sender, EventArgs e )
        {
            Product product = new Product();
            product.Name = _txtName.Text;
            product.Description = _txtName.Text;
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
