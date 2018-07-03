using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraInterface
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            Form users = new Users();
            users.TopLevel = false;
            pnlPrincipal.Controls.Add(users);
            users.Show();
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            Form movies = new Movies();
            movies.TopLevel = false;
            pnlPrincipal.Controls.Add(movies);
            movies.Show();
        }

        private void btnBorrows_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            Form borrow = new Borrows();
            borrow.TopLevel = false;
            pnlPrincipal.Controls.Add(borrow);
            borrow.Show();
        }

        private void lblFechar_MouseHover(object sender, EventArgs e)
        {
            lblFechar.ForeColor = Color.Red;
        }

        private void lblFechar_MouseLeave(object sender, EventArgs e)
        {
            lblFechar.ForeColor = Color.Black;
        }

        private void lblMinimizar_MouseHover(object sender, EventArgs e)
        {
            lblMinimizar.ForeColor = Color.Red;
        }

        private void lblMinimizar_MouseLeave(object sender, EventArgs e)
        {
            lblMinimizar.ForeColor = Color.Black;
        }
    }
}
