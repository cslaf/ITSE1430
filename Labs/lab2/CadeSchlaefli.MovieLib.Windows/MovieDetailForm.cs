using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadeSchlaefli.MovieLib.Windows
{
    public partial class MovieDetailForm : Form
    {

        public Movie Movie { get; set; }
        public MovieDetailForm()
        {
            InitializeComponent();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void OnSave( object sender, EventArgs e )
        {
            Movie movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Length = ConvertToPrice(_txtLength);

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private int ConvertToPrice( TextBox control )
        {
            if (Int32.TryParse(control.Text, out var length))
                return length;

            return -1;
        }
    }
}
