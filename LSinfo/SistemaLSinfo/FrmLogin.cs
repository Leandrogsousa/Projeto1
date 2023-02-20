using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaLSinfo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=LSinfo;Data Source=LEANDRO_SOUSA");
            SqlCommand cmd = new SqlCommand("select * from Usuario where logins =@logins and senha =@senha", cn);
            
            cmd.Parameters.Add("@logins", SqlDbType.VarChar).Value = txtfrmlogin.Text;
            cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtfrmsenha.Text;

            try
            {
                cn.Open();
                SqlDataReader drms = cmd.ExecuteReader();
                if (drms.HasRows == false)
                {
                    throw new Exception("Usuário ou Senha Incorreta.");
                }

                drms.Read();
                MessageBox.Show("Login com Sucesso, Seja Bem Vindo ao LS INFO", "SISTEMA - LSINFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmPrincipal frmpri = new FrmPrincipal();
                frmpri.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }






           
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
