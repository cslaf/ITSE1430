/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 3/11/2018
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadeSchlaefli.MovieLib.Data;
using CadeSchlaefli.MovieLib.Data.Memory;

namespace CadeSchlaefli.MovieLib.Windows
{
    public partial class MainForm : Form
    {
        private MovieDatabase _database = new MemoryMovieDatabase();

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
            var movies = _database.GetAll();

            dataGridView.DataSource = movies.ToList();
        }

        private Movie GetSelectedMovie()
        {
            if (dataGridView.SelectedRows.Count > 0)
                return dataGridView.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void OnExit( object sender, EventArgs e )
        {
            if (ShowConfirmation("Are you sure you want to quit?", "Close"))
                Close();
        }

        private void OnMovieAdd( object sender, EventArgs e )
        {
            var form = new MovieDetailForm("Add Movie");
            if (form.ShowDialog(this) != DialogResult.OK)
                return;
            _database.Add(form.Movie);
            //if (!String.IsNullOrEmpty(message))
            //    MessageBox.Show(message);

            RefreshUI();

        }

        private void OnMovieEdit( object sender, EventArgs e )
        {
            EditSelectedMovie();
        }

        private void OnMovieRemove( object sender, EventArgs e )
        {
            RemoveSelectedMovie();
        }

        private void OnHelp( object sender, EventArgs e )
        {
            var about = new AboutBox1();

            about.Show();

        }
        private bool ShowConfirmation( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        
        private void RemoveSelectedMovie()
        {
            var movie = GetSelectedMovie();

            if (movie == null)
            {
                MessageBox.Show(this, "No Movie to delete");
                return;
            } else if (ShowConfirmation("Are you sure you want to delete the movie?", "Delete Movie"))
                _database.Remove(movie.Id);

            RefreshUI();

        }

        private void EditSelectedMovie()
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var form = new MovieDetailForm(movie);

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //update product
            form.Movie.Id = movie.Id;
            _database.Update(form.Movie);
            //if (!String.IsNullOrEmpty(message))
            //    MessageBox.Show(message);

            RefreshUI();
        }

        private void dataGridView_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if(e.RowIndex != -1)
                EditSelectedMovie();
        }


        private void dataGridView_KeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditSelectedMovie();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedMovie();
                e.Handled = true;
            }

        }
    }
}
