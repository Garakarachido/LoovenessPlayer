using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LoovenessPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder
lpstrReturnString, int uReturnLength, int hwdCallBack);
        Queue<string> q = new Queue<string>();
        string[] Musics = new string[1000];
        int cont;
        string a;



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
               for(int i=0;i<open.FileNames.LongLength;i++)
                {
                    if (listBox1.Items.Contains(open.FileNames.GetValue(i))== false){
                        var r = open.SafeFileNames.GetValue(i);
                        a = Convert.ToString(r);
                        q.Enqueue(a);
                        Musics[cont] = open.FileNames.GetValue(i).ToString();
                        cont += 1;

                    }
                }
                listBox1.Items.Clear();
                foreach(string id in q)
                {
                    listBox1.Items.Add(id);
                }
                if (listBox1.SelectedIndex < 0)
                {
                    listBox1.SetSelected(0, true);
                }
             }
                
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Musics[listBox1.SelectedIndex];
            timer1.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
            {
                listBox1.SetSelected(listBox1.SelectedIndex + 1, true);
                axWindowsMediaPlayer1.URL = Musics[listBox1.SelectedIndex];

            }
            else
            {
                listBox1.SelectedIndex = 0;
                axWindowsMediaPlayer1.URL = Musics[listBox1.SelectedIndex];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 0)
            {
                listBox1.SetSelected(listBox1.SelectedIndex - 1, true);
                axWindowsMediaPlayer1.URL = Musics[listBox1.SelectedIndex];

            }
            else
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                axWindowsMediaPlayer1.URL = Musics[listBox1.SelectedIndex];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String[] arr = q.ToArray();
            String search = textBox1.Text;
            var items = (from a in arr where a.StartsWith(search) select a).ToArray<string>();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(items);


        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
