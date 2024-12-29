using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCase
{
    public partial class Form2 : Form
    {
        public readonly Image[] Images = { Resource1._1, Resource1._2, Resource1._3, Resource1._4, Resource1._5, Resource1.jsb };
        public readonly Dictionary<byte, string> ResultMessage = new Dictionary<byte, string>(3);
        public Form2()
        {
            InitializeComponent();
            ResultMessage.Add(0,"电脑和玩家平手！");
            ResultMessage.Add(1,"玩家获胜！");
            ResultMessage.Add(2,"电脑获胜！");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Start(2);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Start(3);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Start(4);
        }
        private void Start(int userSelect)
        {
            PlayAction.Image = Images[userSelect];
            ComputerAction.Image = PlayGame.ComputerActionImage(userSelect, out var res);
            MessageBox.Show(ResultMessage[res], @"比赛结果");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
