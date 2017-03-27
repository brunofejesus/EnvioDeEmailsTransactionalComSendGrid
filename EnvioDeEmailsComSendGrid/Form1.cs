using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvioDeEmailsComSendGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                ServicoEmail.EnviarRedefinicaoSenha(txtEmail.Text, txtNome.Text, txtUrl.Text);
                MessageBox.Show("Email Enviado Com Sucesso!",
                    "Mensagem Do Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu um erro ao enviar\n{0}", ex.Message),
                    "Mensagem Do Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
    }
}
