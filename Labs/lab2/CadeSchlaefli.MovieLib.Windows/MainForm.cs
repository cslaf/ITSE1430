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
    public partial class MainForm : Form
    {
        Movie _movie;
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);
        }

        private void OnExit( object sender, EventArgs e )
        {
            if (ShowConfirmation("Are you sure you want to quit?", "Close"))
                Close();
        }

        private void OnMovieAdd( object sender, EventArgs e )
        {
            var form = new MovieDetailForm();
            form.Text = "Add Movie";
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            _movie = form.Movie;
        }

        private void OnMovieEdit( object sender, EventArgs e )
        {
            var form = new MovieDetailForm();
            if (_movie == null)
            {
                MessageBox.Show(this, "No Movie to edit");
                return;
            }

            form.Text = "Edit Movie";
            form.Movie = _movie;
            if (form.ShowDialog(this) == DialogResult.OK)
                _movie = form.Movie;
        }

        private void OnMovieRemove( object sender, EventArgs e )
        {
            if (_movie == null)
                MessageBox.Show(this, "No Movie to delete");
            else if (ShowConfirmation("Are you sure you want to delete the movie?", "Delete Movie"))
                _movie = null;
                
        }

        private void OnHelp( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.Show();

        }
        private bool ShowConfirmation( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
    }
}
