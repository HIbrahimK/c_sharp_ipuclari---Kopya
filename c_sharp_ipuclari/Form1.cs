using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_ipuclari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DizinAc_Click(object sender, EventArgs e)
        {
            dizinListeleme dizinList = new dizinListeleme();
            dizinList.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://jn7.net/c-ile-dizin-icerisindeki-belli-tip-dosyalari-listeleme/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            capsLock_Kontrolu caps = new capsLock_Kontrolu();
            caps.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aramaYapma ara = new aramaYapma();
            ara.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            degisiklik_Izleme degisiklik = new degisiklik_Izleme();
            degisiklik.ShowDialog();
        }
    }
}
