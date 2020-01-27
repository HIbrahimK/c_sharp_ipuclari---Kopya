using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_ipuclari
{
    public partial class degisiklik_Izleme : Form
    {
        public degisiklik_Izleme()
        {
            InitializeComponent();
        }

        private void degisiklik_Izleme_Load(object sender, EventArgs e)
        {
            string dizin = "C:";
            DirectoryWatcher(dizin);
            DizinIceriginiListeyeEkle(dizin);
            // again, stupid code to just keep the function alive       
            while (true)
            {
                Thread.Sleep(1000);
            }

        }
        public  void DizinIceriginiListeyeEkle(string dizin)
        {
            string[] dizindekiKlasorler = Directory.GetDirectories(dizin);
            string[] dizindekiDosyalar = Directory.GetFiles(dizin);
            foreach (string klasor in dizindekiKlasorler)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(klasor);
                string klasorAdi = dirInfo.Name;
                DateTime olsTarihi = dirInfo.CreationTime;
                listBox1.Items.Add(klasorAdi+ olsTarihi);
                Console.WriteLine("{0} ...{1}...", klasorAdi, olsTarihi);
            }
            foreach (string dosya in dizindekiDosyalar)

            {
                FileInfo fileInfo = new FileInfo(dosya);
                string dosyaAdi = fileInfo.Name;
                long byteBoyut = fileInfo.Length;
                DateTime olsTarihi = fileInfo.CreationTime;
                listBox2.Items.Add(dosyaAdi+ byteBoyut+ olsTarihi);
                Console.WriteLine("{0} ...{1} ...{2} ...", dosyaAdi, byteBoyut, olsTarihi);
            }
        }
        public  void DirectoryWatcher(string directoryToWatch)
        {             // check incoming arguments          
            if (string.IsNullOrWhiteSpace(directoryToWatch))
                throw new ArgumentNullException("directoryToWatch");
            // create a new FileSystemWatcher      
            FileSystemWatcher w = new FileSystemWatcher();
            // set the directory to watch             w.Path = directoryToWatch;          
            //this is the heart - setup multiple filters        
            // to watch various types of changes to watch       
            w.NotifyFilter = NotifyFilters.Size |
             NotifyFilters.FileName | NotifyFilters.DirectoryName |
               NotifyFilters.CreationTime;
            // setup which file types do we want to monitor          
            w.Filter = "*.*";
            // setup event handlers to watch for changes         
            w.Changed += watcher_Change; w.Created += watcher_Change;
            w.Deleted += watcher_Change; w.Renamed += new RenamedEventHandler(watcher_Renamed);
            // just some debugging        
            Console.WriteLine("Manipulate files in {0} to see activity...", directoryToWatch);
            // enable watching by allowing events to be raised    
           // w.EnableRaisingEvents = true;
        }
         void watcher_Change(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} changed ({1})", e.Name, e.ChangeType);
        }
         void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("{0} renamed to {1}", e.OldName, e.Name);

        }
    }
}
