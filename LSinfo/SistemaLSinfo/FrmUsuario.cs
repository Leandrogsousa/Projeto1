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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void btnadicionar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=LSinfo;Data Source=LEANDRO_SOUSA");
            SqlCommand cmd = new SqlCommand("insert into Usuario(id_usuario,nome,logins,senha,telefone,email,perfil) " +
                                            "Values(@id_usuario,@nome,@logins,@senha,@telefone,@email,@perfil)");
            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = txtid.Text;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtnome.Text;
            cmd.Parameters.Add("@logins", SqlDbType.VarChar).Value = txtlogin.Text;
            cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtsenha.Text;
            cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = txttelefone.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtemail.Text;
            cmd.Parameters.Add("@perfil", SqlDbType.VarChar).Value = comboperfil.Text;

            if (txtid.Text != "" & txtnome.Text != "" & txtlogin.Text != "" & txtsenha.Text != "" & txtemail.Text != "" & comboperfil.Text != "")
            {
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Efetuado Com Sucesso!", "SISTEMA LSINFO - CADASTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtid.Text = "";
                    txtnome.Text = "";
                    txtlogin.Text = "";
                    txtsenha.Text = "";
                    txtemail.Text = "";
                    comboperfil.Text = "";
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
            else
            {
                MessageBox.Show("Por favor digita todas informações nos campos obrigatórios", "SISTEMA LSINFO - CAMPOS OBRIGATÓRIOS", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
