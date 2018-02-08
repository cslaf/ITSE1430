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
        public MainForm()
        {
            MainMenu mainMenu1 = new MainMenu();

            string[] fileItems = { "Exit" },
                movieItems = { "Add", "Edit", "Delete" },
                helpItems = { "About" };

            Movie movie = new Movie();

            //this is a dumb way to initialize apparently
            MenuItem fileMenu = MakeMenu("File", fileItems);
            MenuItem movieMenu = MakeMenu("Movie", movieItems);
            MenuItem helpMenu = MakeMenu("Help", helpItems);

            mainMenu1.MenuItems.Add(fileMenu);
            mainMenu1.MenuItems.Add(movieMenu);
            mainMenu1.MenuItems.Add(helpMenu);


            Menu = mainMenu1;

            InitializeComponent();
        }

        public MenuItem MakeMenu(string header, string[] items)
        {
            MenuItem headerMenu = new MenuItem();

            headerMenu.Text = header;

            foreach(var item in items)
            {
                MenuItem toAdd = new MenuItem();
                toAdd.Text = item;
                headerMenu.MenuItems.Add(toAdd);
            }

            return headerMenu;
        }

        protected override void OnLoad( EventArgs e )
        {


            base.OnLoad(e);
        }
    }
}
