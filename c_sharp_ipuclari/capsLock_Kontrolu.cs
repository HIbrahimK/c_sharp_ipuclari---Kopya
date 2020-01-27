using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace c_sharp_ipuclari
{
    public partial class capsLock_Kontrolu : Form
    {

        public capsLock_Kontrolu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToggleCapsLock(true);
            tusKontrol();
        }
        // ReSharper disable InconsistentNaming
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        static void ToggleCapsLock(bool onOrOff)
        {
            if (IsKeyLocked(Keys.CapsLock) == onOrOff) return;
            keybd_event(0x14, 0x45, 0x1, (UIntPtr)0);
            keybd_event(0x14, 0x45, 0x1 | 0x2, (UIntPtr)0);

        }

        private void capsLock_Kontrolu_Load(object sender, EventArgs e)
        {

            tusKontrol();


        }
        public void tusKontrol()
        {
            bool isNumLockToggled = Keyboard.IsKeyToggled(Key.NumLock);
            bool isCapsLockToggled = Keyboard.IsKeyToggled(Key.CapsLock);
            bool isScrollLockToggled = Keyboard.IsKeyToggled(Key.Scroll);
            if (isCapsLockToggled)
            {
                label1.Text = "capsLock Kapalı";
            }
            else
            {
                label1.Text = "capsLock Açık";
            }
            if (isNumLockToggled)
            {
                label2.Text = "numLock Kapalı";
            }
            else
            {
                label2.Text = "numLock Açık";
            }
            if (isScrollLockToggled)
            {
                label3.Text = "ScrollLock Kapalı";
            }
            else
            {
                label3.Text = "ScrollLock Açık";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToggleCapsLock(false);
            tusKontrol();

        }
        // ReSharper restore InconsistentNaming
    }
}
