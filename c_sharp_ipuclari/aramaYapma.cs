using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_ipuclari
{
    public partial class aramaYapma : Form
    {
        public aramaYapma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            boya(txtSearch.Text, Color.Red, false);
        }
        public void boya(string kelime, Color renk, Boolean tamam)
        {
            int textEnd = richTextBox1.TextLength;
            int index = 0;
            int lastIndex = richTextBox1.Text.LastIndexOf(kelime);

            while (index < lastIndex)
            {
                if (tamam)
                {
                    richTextBox1.Find(kelime, index, textEnd, RichTextBoxFinds.WholeWord);
                }
                else
                {
                    richTextBox1.Find(kelime, index, textEnd, RichTextBoxFinds.None);
                }

                richTextBox1.SelectionBackColor = renk;
                index = richTextBox1.Text.IndexOf(kelime, index) + 1;
            }

        }
    }
}
