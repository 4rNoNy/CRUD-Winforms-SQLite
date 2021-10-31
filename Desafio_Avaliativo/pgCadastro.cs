using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Desafio_Avaliativo
{
    public partial class pgCadastro : MetroFramework.Forms.MetroForm
    {
        bool Ativado = true;


        public pgCadastro()

        {
            InitializeComponent();
        }
        

        private void pgCadastro_Load(object sender, EventArgs e)
        {

        }

        private void panelcontender_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }
        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = projectCode.GetPessoas();
                dgvDados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                MessageBox.Show("Informe os dados cliente a incluir");
                return;
            }
            try
            {
                Pessoa pssa = new Pessoa();
                
                pssa.pcd = txtAtivo.Text;
                pssa.nome = txtNome.Text;
                pssa.sobrenome = txtSobrenome.Text;
                pssa.datanascimento = txtNascimento.Text;
                pssa.altura = txtAltura.Text;

                projectCode.Add(pssa);

                ExibirDados();
                LimpaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }


        }

        private void LimpaDados()
        {
            
            txtNome.Text = "";
            txtSobrenome.Text = "";
            txtAltura.Text = "";
            txtNascimento.Text = "";
            txtPesquisar.Text = "";
        }

        private bool Valida()
        {
            if (string.IsNullOrEmpty(txtNome.Text) && string.IsNullOrEmpty(txtSobrenome.Text) && string.IsNullOrEmpty(txtNascimento.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtAtivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

            if (Ativado == true)
            {
                Ativado = false;
                txtAtivo.Text = "Não";
            }
            else
            {
                Ativado = true;
                txtAtivo.Text = "Sim";
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPesquisar.Text))
            {
                MessageBox.Show("Informe o ID do cliente a ser Localizado");
                return;
            }
            try 
            {
                DataTable dt = new DataTable();
                int codigo = Convert.ToInt32(txtPesquisar.Text);

                dt = projectCode.GetPessoa(codigo);
                dgvDados.DataSource = dt;
                }

            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
                     
                
            }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPesquisar.Text))
            {
                MessageBox.Show("Informe o ID do cliente a ser Excluído");
                return;
            }
            try
            {
                int codigo = Convert.ToInt16(txtPesquisar.Text);
                projectCode.Delete(codigo);
                ExibirDados();
                LimpaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                MessageBox.Show("Informe os dados cliente a atualizar");
                return;
            }

            try
            {
                Pessoa psa = new Pessoa();
                psa.id = Convert.ToInt32(txtPesquisar.Text);
                psa.pcd = txtAtivo.Text;
                psa.nome = txtNome.Text;
                psa.sobrenome = txtSobrenome.Text;
                psa.altura = txtAltura.Text;
                psa.datanascimento = txtNascimento.Text;

                projectCode.Update(psa);
                ExibirDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
            LimpaDados();
        }

        private void txtSobrenome_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
