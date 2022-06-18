using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class TittleForm : Form
    {
        ResizeHandler Sizer = new ResizeHandler();
        public TittleForm()
        {
            InitializeComponent();
            Sizer.Form = this;
            Sizer.GroupBox = gbServer;
        }
        private void TitleForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(Variables.filepath))
                btLoad_Click_1(sender, e);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbServer.Text = "192.168.0.94";
            tbPort.Text = "3306";
            tbDB.Text = "is-31-muratovv";
            tbLogin.Text = "is-31-muratovv";
            tbPassword.Text = "cIuUsT";
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            DB.FillConnection(tbServer.Text, tbPort.Text, tbDB.Text, tbLogin.Text, tbPassword.Text);
            if (DB.TestConnection())
            {
                AuthForm frm = new AuthForm();
                Hide();
                frm.ShowDialog();
            }
        }
        private void btSettings_Click_1(object sender, EventArgs e)
        {
            Sizer.TittleResize();
        }
        private void btExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btLoad_Click_1(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            DB.LoadConnection(tbServer, tbPort, tbDB, tbLogin, tbPassword);
        }
        private void btOpenDir_Click_1(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            DB.OpenDirectory();
        }
    }
}
