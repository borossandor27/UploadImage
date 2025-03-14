using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UploadImage
{
    public partial class Form1 : Form
    {
        List<User> users = new List<User>(); // Inicializáljuk, hogy ne legyen null
        string baseUrl = "http://localhost:5000";
        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getImages(); // Megvárjuk az adatok lekérését
            DisplayImages(); // Csak utána jelenítjük meg a képeket
        }

        private async Task getImages()
        {
            string apiUrl = $"{baseUrl}/uploads";
            var response = await client.GetAsync(apiUrl);
            var jsonString = await response.Content.ReadAsStringAsync();
            users = User.FromJson(jsonString);
        }

        private void DisplayImages()
        {
            if (users == null || users.Count == 0)
                return;

            foreach (var user in users)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 100, // Példa méret
                    Height = 100,
                    Left = 10,  // Példa elhelyezés
                    Top = 10 + (users.IndexOf(user) * 110) // Minden kép alatt kicsit lejjebb jelenjen meg
                };

                try
                {
                    string imageUrl = $"{baseUrl}{user.ImageUrl}";
                    pictureBox.Load(imageUrl);
                    this.Controls.Add(pictureBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba a kép betöltésekor: {ex.Message}");
                }
            }
        }
    }
}
