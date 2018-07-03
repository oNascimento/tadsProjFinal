using LocadoraInterface.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraInterface
{
    public partial class Users : Form
    {
        string URI = "http://localhost:49790/api/Users";

        public Users()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
        }
        private async void GetAllUsers()
        {
            
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        dgvUsers.DataSource = JsonConvert.DeserializeObject<User[]>(ProdutoJsonString).ToList();

                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }
        private async void AddUser()
        {
            User user = new User();
            user.name = txtName.Text;
            user.email = txtEmail.Text;

            using (var client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(user);
                var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }
            GetAllUsers();
        }
        private async void UpdateUser()
        {
            User user = new User();
            user.id = Convert.ToInt32(txtId.Text);
            user.name = txtName.Text;
            user.email = txtEmail.Text;

            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URI + "/" + user.id, user);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuário atualizado");
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o usuario : " + responseMessage.StatusCode);
                }
            }
            GetAllUsers();
        }
        private async void DeleteUser(int codUser)
        {
            int userId = codUser;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", URI, userId));
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o usuario  : " + responseMessage.StatusCode);
                }
            }
            GetAllUsers();
        }
        private void Users_Load(object sender, EventArgs e)
        {
            GetAllUsers();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            AddUser();
            Clear();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvUsers.SelectedCells[0].Value.ToString();
            txtName.Text = dgvUsers.SelectedCells[1].Value.ToString();
            txtEmail.Text = dgvUsers.SelectedCells[2].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                MessageBox.Show("Selecione um usuario antes");
            }
            else
            {
                UpdateUser();
                Clear();
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                MessageBox.Show("Selecione um usuario antes");
            }
            else
            {
                DeleteUser(Convert.ToInt32(txtId.Text));
                Clear();
            }
        }
    }

    
}
