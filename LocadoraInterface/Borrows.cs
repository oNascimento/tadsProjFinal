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
    public partial class Borrows : Form
    {
        public Borrows()
        {
            InitializeComponent();
        }

        private async void GetAllBorrows()
        {
            string URI = "http://localhost:49790/api/Borrows";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        dgvBorrow.DataSource = JsonConvert.DeserializeObject<Borrow[]>(ProdutoJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o Emprestimo : " + response.StatusCode);
                    }
                }
            }
        }
        private async void GetUserById(int codUser)
        {
            string URI = "http://localhost:49790/api/Users";

            using (var client = new HttpClient())
            {
                BindingSource bsDados = new BindingSource();
                URI += "/" + codUser.ToString();

                HttpResponseMessage response = await client.GetAsync(URI);
                if (response.IsSuccessStatusCode)
                {
                    var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                    bsDados.DataSource = JsonConvert.DeserializeObject<User>(ProdutoJsonString);
                    dgvUsers.DataSource = bsDados;
                }
                else
                {
                    MessageBox.Show("Falha ao obter o usuario : " + response.StatusCode);
                }
            }
        }
        private async void GetMovieById(int codMovie)
        {
            string URI = "http://localhost:49790/api/Movies";

            using (var client = new HttpClient())
            {
                BindingSource bsDados = new BindingSource();
                URI += "/" + codMovie.ToString();

                HttpResponseMessage response = await client.GetAsync(URI);
                if (response.IsSuccessStatusCode)
                {
                    var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                    bsDados.DataSource = JsonConvert.DeserializeObject<Movie>(ProdutoJsonString);
                    dgvMovie.DataSource = bsDados;
                }
                else
                {
                    MessageBox.Show("Falha ao obter o Filme : " + response.StatusCode);
                }
            }
        }
        private async void AddBorrow()
        {
            string URI = "http://localhost:49790/api/Borrows";

            User user = new User();
            user.id = Convert.ToInt32(dgvUsers.SelectedCells[0].Value);
            user.name = dgvUsers.SelectedCells[1].Value.ToString();
            user.email = dgvUsers.SelectedCells[2].Value.ToString();

            Movie movie = new Movie();
            movie.id = Convert.ToInt32(dgvMovie.SelectedCells[0].Value);
            movie.name = dgvMovie.SelectedCells[1].Value.ToString();
            movie.year = Convert.ToInt32(dgvMovie.SelectedCells[2].Value);

            Borrow borrow = new Borrow();
            borrow.movieId = movie.id;
            borrow.userId = user.id;
            borrow.date = DateTime.Now.ToShortDateString();

            using (var client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(borrow);
                var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }

            GetAllBorrows();
        }
        private async void UpdateBorrow()
        {
            string URI = "http://localhost:49790/api/Borrows";

            Borrow borrow = new Borrow();
            borrow.id = Convert.ToInt32(txtId.Text);
            borrow.movieId = Convert.ToInt32(textBox1.Text);
            borrow.userId = Convert.ToInt32(txtUserID.Text);
            borrow.date = dgvBorrow.SelectedCells[3].Value.ToString();

            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URI + "/" + borrow.id, borrow);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Empréstimo atualizado");
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o usuario : " + responseMessage.StatusCode);
                }
            }

            GetAllBorrows();
        }
        private async void DeleteBorrow(int codUser)
        {
            string URI = "http://localhost:49790/api/Borrows";
            int userId = codUser;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", URI, userId));
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Empréstimo excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o usuario  : " + responseMessage.StatusCode);
                }
            }
            GetAllBorrows();
        }
        private void Borrow_Load(object sender, EventArgs e)
        {
            GetAllBorrows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetUserById(Convert.ToInt32(txtUserID.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GetMovieById(Convert.ToInt32(textBox1.Text));
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            AddBorrow();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            UpdateBorrow();
        }

        private void dgvBorrow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvBorrow.SelectedCells[0].Value.ToString();
            txtUserID.Text = dgvBorrow.SelectedCells[1].Value.ToString();
            textBox1.Text = dgvBorrow.SelectedCells[2].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DeleteBorrow(Convert.ToInt32(txtId.Text));
        }
    }
}
