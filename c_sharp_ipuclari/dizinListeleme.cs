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

namespace c_sharp_ipuclari
{
    public partial class dizinListeleme : Form
    {
        public dizinListeleme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtParagraphs.Text = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string sourceDir = dialog.SelectedPath;
            string[] sourcefiles = Directory.GetFiles(sourceDir);
            string sourcefile;

            for (int i = 0; i < sourcefiles.Length; i++)
            {
                sourcefile = sourcefiles[i];
                FileInfo info = new FileInfo(sourcefile);
                string uzanti = info.Extension; //Dosya Uzantısını alıyoruz.
                if (uzanti == ".txt")//sadece txt uzantılı dosyaları alıyoruz.
                {

                    //Sadece dosya isimlerini yazdırmak için kullanılır
                    try
                    {
                        txtParagraphs.Text = txtParagraphs.Text + ("\nDosya Adı   : " + sourcefile + "\n");

                    }
                    catch (IOException)
                    {
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtParagraphs.Text = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string sourceDir = dialog.SelectedPath;
            string[] sourcefiles = Directory.GetFiles(sourceDir);
            string sourcefile;

            for (int i = 0; i < sourcefiles.Length; i++)
            {
                sourcefile = sourcefiles[i];
                FileInfo info = new FileInfo(sourcefile);
                string uzanti = info.Extension; //Dosya Uzantısını alıyoruz.
                if (uzanti == ".txt")//sadece txt uzantılı dosyaları alıyoruz.
                {
                    txtParagraphs.Text = txtParagraphs.Text + ("\nDosya Adı   : " + sourcefile + "\n");
                    //Sadece dosya isimlerini yazdırmak için kullanılır
                    try
                    {
                        string text = File.ReadAllText(sourcefile, Encoding.GetEncoding(1254));
                        txtParagraphs.Text = txtParagraphs.Text + "\n" + text;
                        //txt dosya içeriklerini formdaki metin kutusuna eklemek için kullanılır.
                    }
                    catch (IOException)
                    {
                    }
                }
            }
        }
    }
}