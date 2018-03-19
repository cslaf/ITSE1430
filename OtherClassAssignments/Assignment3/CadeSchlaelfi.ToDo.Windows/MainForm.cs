using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadeSchlaefli.ToDo;

namespace CadeSchlaelfi.ToDo.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        //reads and writes to save file
        private void RefreshUI()
        {
            if (hidingCompleted)
                hideCompleted();
            return;

        }


        private void dataGridView1_CellValidating( object sender, DataGridViewCellValidatingEventArgs e )
        {
            var header = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            var toCheck = e.FormattedValue.ToString();
            //handle DueDate, Title, and Priority Validation

            if (header.Equals("Priority") && !Int32.TryParse(toCheck, out var priority))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "Priority must be an whole number";
                e.Cancel = true;
            }

            if (header.Equals("Title") && String.IsNullOrEmpty(toCheck))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "Title cannot be empty";
                e.Cancel = true;
            }

            if (header.Equals("Due Date") && !DateTime.TryParse(toCheck, out var date))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "Date is invalid";
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void dataGridView1_CellEndEdit( object sender, DataGridViewCellEventArgs e )
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;

            RefreshUI();
        }

        private void MainForm_Load( object sender, EventArgs e )
        {

            var view = new SortableBindingList<ToDoItem>();

            dataGridView1.DataSource = view;

        }

        ListSortDirection sort = new ListSortDirection();
        private void dataGridView1_ColumnHeaderMouseClick( object sender, DataGridViewCellMouseEventArgs e )
        {
            if (sort == ListSortDirection.Descending)
                sort = ListSortDirection.Ascending;
            else
                sort = ListSortDirection.Descending;
            var toSort = dataGridView1 as IBindingListView;
            dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], sort);
        }

        private void saveToolStripMenuItem1_Click( object sender, EventArgs e )
        {
            var saveInput = new SaveFileDialog();

            if (saveInput.ShowDialog() != DialogResult.OK)
                return;

            var toSave =  dataGridView1.DataSource as SortableBindingList<ToDoItem>;
            if(toSave != null)
                toSave.Save(saveInput.FileName);

        }

        private void loadToolStripMenuItem1_Click( object sender, EventArgs e )
        {
            var loadInput = new OpenFileDialog();

            if (loadInput.ShowDialog() != DialogResult.OK || !loadInput.CheckFileExists)
                return;

            var toLoad = dataGridView1.DataSource as SortableBindingList<ToDoItem>;
            if (toLoad != null)
                toLoad.Load(loadInput.FileName);
            
        }

        private void hideCompleted()
        {
            
            var index = dataGridView1?.CurrentRow?.Index;

            index = index ?? -1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[5].Value is bool && (bool)row.Cells[5].Value && hidingCompleted && row.Index != index)
                {
                    row.Visible = false;
                } 
                else
                if(!hidingCompleted)
                    row.Visible = true;
            }
        }

        private bool hidingCompleted = false;
        private void hideCompletedItemsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            hidingCompleted = !hidingCompleted;

            dataGridView1.CurrentCell = null;
            hideCompleted();
        }

        private void dataGridView1_RowLeave( object sender, DataGridViewCellEventArgs e )
        {
            RefreshUI();
        }

        private void dataGridView1_RowEnter( object sender, DataGridViewCellEventArgs e )
        {
            RefreshUI();
        }
    }
}
