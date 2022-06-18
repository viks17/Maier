using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public partial class ChangePassForm : Form
    {
        public ChangePassForm()
        {
            InitializeComponent();
        }
        public bool ExecuteCommand(MySqlCommand command)
        {
            bool bl = true;
            try
            {
                Variables.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception x) { MessageBox.Show(x.ToString()); bl = false; }
            if (Variables.Connection.State == ConnectionState.Open)
                Variables.Connection.Close();
            return bl;
        }       

        private void byChangePass_Click(object sender, EventArgs e)
        {
            if (!(tbOldPass.Text == "" | tbNewPass.Text == "" | tbNewPassConfirm.Text == ""))
            {
                if (!(tbOldPass.Text == tbNewPass.Text))
                {
                    if (tbNewPass.Text == tbNewPassConfirm.Text)
                    {
                        DataBase DB = new DataBase();
                        DB.ChangePass(tbOldPass.Text, tbNewPassConfirm.Text);
                    }
                    else
                        MessageBox.Show("Новый пароль и подтверждение различиаются.", "Пароль не изменён", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Новый пароль не должен совпадать со старым паролем.", "Пароль не изменён", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Одно или несколько полей не заполнены", "Пароль не изменён", MessageBoxButtons.OK);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
