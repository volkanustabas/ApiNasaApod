using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ApiNasaApod
{
    public partial class FrmMain : Form
    {
        private Apod _mdc;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            JsonProcess();

            lbl_copyright.Text = _mdc.copyright;
            lbl_date.Text = _mdc.date;
            lbl_title.Text = _mdc.title;
            rtb_explanation.Text = _mdc.explanation;
            pb_picture.ImageLocation = _mdc.hdurl;
            pb_picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void JsonProcess()
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(
                    "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY");
                _mdc = JsonConvert.DeserializeObject<Apod>(json);
            }
        }


        public class Apod
        {
            public string copyright { get; set; }
            public string date { get; set; }
            public string explanation { get; set; }
            public string hdurl { get; set; }
            public string media_type { get; set; }
            public string service_version { get; set; }
            public string title { get; set; }
            public string url { get; set; }
        }
    }
}