using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UploadImage
{
    public partial class FormUserProfil : Form
    {
        List<User> users = new List<User>(); // Inicializáljuk, hogy ne legyen null
        string baseUrl = "http://localhost:5000";
        HttpClient client = new HttpClient();

        public FormUserProfil()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_UserProfilImage.SizeMode = PictureBoxSizeMode.StretchImage; // Kép méretezése a PictureBox-ban
            openFileDialog_imageUpload.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog_imageUpload.Title = "Select an Image File";
            openFileDialog_imageUpload.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog_imageUpload.RestoreDirectory = true;
            openFileDialog_imageUpload.FileName = string.Empty; // Üres fájlnév beállítása
            openFileDialog_imageUpload.CheckFileExists = true; // Ellenőrizzük, hogy a fájl létezik-e
            openFileDialog_imageUpload.CheckPathExists = true; // Ellenőrizzük, hogy az útvonal létezik-e
            openFileDialog_imageUpload.Multiselect = false; // Csak egy fájl kiválasztása engedélyezett
            openFileDialog_imageUpload.FilterIndex = 1; // Alapértelmezett szűrőindex beállítása
            openFileDialog_imageUpload.ShowHelp = true; // Segítség megjelenítése
            openFileDialog_imageUpload.ShowReadOnly = false; // Csak olvasható fájlok engedélyezése
            openFileDialog_imageUpload.ReadOnlyChecked = false; // Csak olvasható fájlok engedélyezése
            openFileDialog_imageUpload.Title = "Select an Image File";
            await getUsers(); // Megvárjuk az adatok lekérését
            // Kép eltávolítása
            pictureBox_UserProfilImage.Image = null;
        }

        private async Task getUsers()
        {
            string apiUrl = $"{baseUrl}/upload";
            var response = await client.GetAsync(apiUrl);
            var jsonString = await response.Content.ReadAsStringAsync();
            if (String.IsNullOrEmpty(jsonString) || jsonString.Equals("[]"))
            {
                users = new List<User>(); // Ha üres a válasz, inicializáljuk üres listával
            }
            else
            {
                users = User.FromJson(jsonString);
            }
            listBox_Users.DataSource = users;
            listBox_Users.DisplayMember = "Username"; // A megjelenítendő mező beállítása
            listBox_Users.ValueMember = "Id"; // Az érték mező beállítása
            listBox_Users.SelectedIndex = -1; // Alapértelmezett kiválasztás eltávolítása
            // Kép eltávolítása
            pictureBox_UserProfilImage.Image = null;
            textBox_Username.Text = string.Empty;
            textBox_Description.Text = string.Empty;
            textBox_id.Text = string.Empty;
            dateTimePicker_Belepes.Value = DateTime.Now; // Alapértelmezett dátum beállítása
        }

        private void listBox_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (users == null || users.Count == 0)
                return;
            if (listBox_Users.SelectedItem != null)
            {
                User selectedUser = (User)listBox_Users.SelectedItem;
                if (selectedUser != null)
                {
                    pictureBox_UserProfilImage.ImageLocation= $"{baseUrl}/uploads/{selectedUser.ImageUrl}";
                    textBox_Username.Text = selectedUser.Username;
                    textBox_Description.Text = selectedUser.Description;
                    textBox_id.Text = selectedUser.Id.ToString();
                    dateTimePicker_Belepes.Value = DateTime.Parse(selectedUser.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
        }

        private async void button_NewUser_Click(object sender, EventArgs e)
        {
            // Új felhasználó létrehozása
            User newUser = new User
            {
                Username = textBox_Username.Text,
                Description = textBox_Description.Text,
                ImageUrl = pictureBox_UserProfilImage.ImageLocation,
                CreatedAt = DateTime.Now
            };
            await Upload();
            textBox_id.Text = string.Empty;
            textBox_Username.Text = string.Empty;
            textBox_Description.Text = string.Empty;
            pictureBox_UserProfilImage.Image = null; // Kép eltávolítása
            textBox_ImageUrl.Text = string.Empty; // Kép URL eltávolítása
            dateTimePicker_Belepes.Value = DateTime.Now; // Alapértelmezett dátum beállítása
            await getUsers(); // Frissítjük a felhasználók listáját
        }
        public async Task Upload()
        {
            string filePath = pictureBox_UserProfilImage.ImageLocation;
            string url = "http://localhost:5000/upload";

            
            using (var form = new MultipartFormDataContent())
            {
                // szöveges mezők
                form.Add(new StringContent(textBox_Username.Text), "username");
                form.Add(new StringContent(textBox_Description.Text), "description");
                form.Add(new StringContent(textBox_ImageUrl.Text), "imageUrl");

                // fájl hozzáadása
                var fileStream = File.OpenRead(filePath);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = null;
                // fájl típusának beállítása
                switch (Path.GetExtension(filePath))
                {
                    case @".jpg":
                    case @".jpeg":
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                        break;
                    case @".png":
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                        break;
                    default:
                        break;
                }
                 // vagy image/png stb.
                form.Add(fileContent, "image", Path.GetFileName(filePath));

                // POST kérés küldése
                HttpResponseMessage response = await client.PostAsync(url, form);

                // válasz feldolgozása
                string result = await response.Content.ReadAsStringAsync();
                // A feltöltés eredményének megjelenítése
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Feltöltés sikeres!");
                }
                else
                {
                    MessageBox.Show("Hiba történt a feltöltés során: " + result);
                }
            }
        }

        private void button_ImageUpload_Click(object sender, EventArgs e)
        {
            // Kép feltöltése
            if (openFileDialog_imageUpload.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog_imageUpload.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                pictureBox_UserProfilImage.ImageLocation = filePath; // Kép megjelenítése a PictureBox-ban
                textBox_ImageUrl.Text = fileName; // Kép URL beállítása
            }
        }
    }
}
