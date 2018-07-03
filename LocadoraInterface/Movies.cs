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
    public partial class Movies : Form
    {
        string URI = "http://localhost:49790/api/Movies";
        public Movies()
        {
            InitializeComponent();
        }
        private void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtYear.Text = "";
        }
        private async void GetAllMovies()
        {

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        dgvMovies.DataSource = JsonConvert.DeserializeObject<Movie[]>(ProdutoJsonString).ToList();

                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o filme : " + response.StatusCode);
                    }
                }
            }
        }
        private async void AddMovie()
        {
            Movie Movie = new Movie();
            Movie.name = txtName.Text;
            Movie.year = Convert.ToInt32(txtYear.Text);

            using (var client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(Movie);
                var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }
            GetAllMovies();
        }
        private async void UpdateMovie()
        {
            Movie Movie = new Movie();
            Movie.id = Convert.ToInt32(txtId.Text);
            Movie.name = txtName.Text;
            Movie.year = Convert.ToInt32(txtYear.Text);

            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URI + "/" + Movie.id, Movie);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuário atualizado");
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o Filme : " + responseMessage.StatusCode);
                }
            }
            GetAllMovies();
        }
        private async void DeleteMovie(int codMovie)
        {
            int MovieId = codMovie;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", URI, MovieId));
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Filme excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o Filme  : " + responseMessage.StatusCode);
                }
            }
            GetAllMovies();
        }
        private void Movies_Load(object sender, EventArgs e)
        {
            GetAllMovies();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            AddMovie();
            Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            UpdateMovie();
            Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DeleteMovie(Convert.ToInt32(txtId.Text));
            Clear();
        }

        private void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvMovies.SelectedCells[0].Value.ToString();
            txtName.Text = dgvMovies.SelectedCells[1].Value.ToString();
            txtYear.Text = dgvMovies.SelectedCells[2].Value.ToString();
        }
    }
}
