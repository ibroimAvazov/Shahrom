using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using WindowsFormsApplication1.Properties;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool _allowClik = true;
        private PictureBox _firstGuess;
        private readonly Random _random = new Random();
        private readonly Timer _clickTimer = new Timer();
       
        int ticks = 60;
        readonly Timer timer = new Timer { Interval = 1000 };
        public Form1()
        {
            InitializeComponent();
            SetRandowImages();
            HideImages();
            StartGameTimer();
            _clickTimer.Interval = 1000;
            _clickTimer.Tick += _clickTimer_Tick;
        }
        private PictureBox[] PictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }

        }
        private static IEnumerable<Image> Images
        {
            get
            {
                return new Image[]
                {

                    Resources.Безымянный1,
                    Resources.Безымянный2,
                    Resources.Безымянный3,
                    Resources.Безымянный4,
                    Resources.Безымянный5,
                    Resources.Безымянный6,
                    Resources.Безымянный7,
                    Resources.Безымянный8,
                    
                };
            }
        }
        private static IEnumerable<Image> Images1
        {
            get
            {
                return new Image[]
                {


                    Resources.img1,
                    Resources.img2,
                    Resources.img3,
                    Resources.img4,
                    Resources.img5,
                    Resources.img6,
                    Resources.img7,
                    Resources.img8,

                    
                };
            }
        }
        private void StartGameTimer()
        {
           
                timer.Stop();
                 timer.Tick += delegate
                {
                    ticks--;
                    if (ticks == -1)
                    {
                        timer.Stop();
                        MessageBox.Show("Проигрыш");
                        ResetImages();
                    }
                    var time = TimeSpan.FromSeconds(ticks);
                    ITime.Text = "00:" + time.ToString("ss");

                };
            
        }
        private void ResetImages()
        {

           
                foreach (var pic in PictureBoxes)
                {
                    pic.Tag = null;
                    pic.Visible = true;
                }
                HideImages();
                SetRandowImages();

                ticks = 60;

            
            }
        
        private void HideImages()
        {
            
                foreach (var pic in PictureBoxes)
                {
                    pic.Image = Resources.img0;
                }

            
        }
        private PictureBox GetFreeSlot()
        {
           
                int num;
                do
                {
                    num = _random.Next(0, PictureBoxes.Count());
                }
                while (PictureBoxes[num].Tag != null);
                return PictureBoxes[num];

            
           

            
        }
        private void SetRandowImages()
        {
            if (checkBox1.Checked == true)
            {
                foreach (var image in Images1)
                {
                    GetFreeSlot().Tag = image;
                    GetFreeSlot().Tag = image;
                }
            }
        }
        private void SetRandowImages1()
        {
            if (checkBox2.Checked == true)
            {
                foreach (var image in Images)
                {
                    GetFreeSlot().Tag = image;
                    GetFreeSlot().Tag = image;

                }
            }

        }
        private void ClickImage(object sender, EventArgs e)
        {

           
                timer.Start();
                if (!_allowClik) return;
                var pic = (PictureBox)sender;
                if (_firstGuess == null)
                {
                    _firstGuess = pic;
                    pic.Image = (Image)pic.Tag;
                    return;

                }
                pic.Image = (Image)pic.Tag;
                if (pic.Image == _firstGuess.Image && pic != _firstGuess)
                {
                    pic.Visible = _firstGuess.Visible = false;
                    {
                        _firstGuess = pic;
                    }
                    HideImages();
                }
                else
                {
                    _allowClik = false;
                    _clickTimer.Start();
                }
                _firstGuess = null;

                if (PictureBoxes.Any(p => p.Visible))
                    return;
                timer.Stop();
                MessageBox.Show("Победа");
                ResetImages();
            

        }
        private void _clickTimer_Tick(object sender, EventArgs e)
        {
            HideImages();
            _allowClik = true;
            _clickTimer.Stop();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                ResetImages();
                SetRandowImages1();
            }
            else checkBox1.Checked = true;
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                ResetImages();
                SetRandowImages1();
            }
            else checkBox2.Checked = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
