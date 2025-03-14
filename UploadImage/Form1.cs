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

namespace UploadImage
{
    public partial class Form1 : Form
    {
        string[] imagesUrls;
        string baseUrl = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getImages();
        }

        private async void getImages()
        {
            
            var response = await client.GetAsync("http://localhost:3000/ugyfelek"); // a teljes tartalmat lekérjük
            var jsonString = await response.Content.ReadAsStringAsync(); // a tartalmat stringgé alakítjuk
            var ugyfelek = Ugyfel.FromJson(jsonString);
            listBox1.Items.AddRange(ugyfelek.ToArray());
            ugyfelek.ToJson();
        }
    }
}
