using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APIConsumer.Helper_Class;

namespace APIConsumer
{
    public partial class Form1 : Form
    {
        
        private int MaxNum = 0;
        private int CurrentNum = 0;

        public Form1()
        {
            InitializeComponent();
            APIHelper.InitializedClient();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            await LoadImage();
        }

        private async Task LoadImage(int ImageNum = 0)
        {
            var comic = await APIProcessor.LoadData(ImageNum);

            if (ImageNum == 0)
            {
                MaxNum = comic.Num;
            }

            CurrentNum = comic.Num;

           
            var urisource = new Uri(comic.Img, UriKind.Absolute);
            pictureBox1.LoadAsync(urisource.ToString());

           

        }

        private async void BtnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentNum > 1)
            {
                CurrentNum -= 1;
                BtnNext.Enabled = true;
                await LoadImage(CurrentNum);

                if (CurrentNum == 1)
                {
                    BtnPrev.Enabled = false;
                }
            }

        }

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            if (CurrentNum < MaxNum)
            {
                CurrentNum += 1;
                BtnPrev.Enabled = true;
                await LoadImage(CurrentNum);

                if (CurrentNum == MaxNum)
                {
                    BtnNext.Enabled = false;
                }
            }
        }
    }
}
