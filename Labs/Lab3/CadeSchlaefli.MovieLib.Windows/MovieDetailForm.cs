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

        protected override void OnLoad( EventArgs e )
        {

            if(Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtDescription.Text = Movie.Description;
                _txtLength.Text = Movie.Length.ToString();
                _chkboxOwned.Checked = Movie.IsOwned;
            }

            ValidateChildren();

            base.OnLoad(e);
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            Movie movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Length = ConvertToLength(_txtLength);
            movie.IsOwned = _chkboxOwned.Checked;

            var message = movie.Validate();

            if (!String.IsNullOrEmpty(message))
            {
                MessageBox.Show(this, movie.Validate(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            Movie = movie;

            DialogResult = DialogResult.OK;
            Close();
        }

        private int ConvertToLength( TextBox control )
        {
            if (control.Text == "")
                return 0;

            if (Int32.TryParse(control.Text, out var length))
                return length;

            return -1;
        }

        private void _txtTitle_Validating( object sender, CancelEventArgs e )
        {
            var textbox = sender as TextBox;

            if (String.IsNullOrEmpty(textbox.Text))
            {
                _errorProvider.SetError(textbox, "Title is Required");
                e.Cancel = true;
            }else
                _errorProvider.SetError(textbox, "");
        }

        private void _txtLength_Validating( object sender, CancelEventArgs e )
        {

            var textbox = sender as TextBox;
            var length = ConvertToLength(textbox);

            if (length < 0)
            {
                _errorProvider.SetError(textbox, "Price must be empty or >=0");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }
    }
}
