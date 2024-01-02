using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUYUKUNLUKUCUKUNLU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

      

        bool buyukUnluCheck(List<string> liste)
        {
            if (liste.Count == 1) return true;
            bool inceMi = false;
            bool kalinMi = false;

            foreach (string item in liste)
            {
                if (item == "e" || item == "i" || item == "ö"||item=="ü")
                {
                    inceMi = true;
                    if (kalinMi) return false;
                }
                else
                {
                    kalinMi = true;
                    if (inceMi) return false;
                }
            }

            return true;
        }

        bool kucukUnluCheck(List<string> liste)
        {
            if (liste.Count == 1) return true;

            string duzUnlu = "aeıi";
            string yuvarlakDar = "uü";
            string düzGeniş = "ae";
            string yuvarlakUnlu = "aouü";
            string diger = "uüae";
            string digerdiger = "oöıi";
            for (int i = 1; i < liste.Count; i++)
            {
                if (duzUnlu.Contains(liste[i-1].ToString()) && yuvarlakUnlu.Contains(liste[i].ToString())) 
                {
                    return false;
                }
                if (yuvarlakUnlu.Contains(liste[i-1].ToString()) && digerdiger.Contains(liste[i].ToString())) 
                {  
                    return false;
                }

            }

            return true;
        }

        private void unluler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wordTxt_TextChanged(object sender, EventArgs e)
        {
            
            List<string> unluler = new List<string>();
            wordTxt.Text = wordTxt.Text.Trim().ToLower();
            label1.Text = "";
            label2.Text = "";
            string word = wordTxt.Text;
            string unluList = "aeıioöuü";
            if (string.IsNullOrEmpty(word)) return;
            foreach (char harf in word)
            {
                if (unluList.Contains(harf.ToString()))
                {
                    unluler.Add(harf.ToString());
                }
            }
            if (unluler.Count == 1)
            {
                label1.Text = word+" kelimesi tek ünlü içerdiği için ünlü uyumu aranmaz.";
            }
            if (buyukUnluCheck(unluler))
            {
                label1.Text = word+" kelimesi büyük ünlü uyumuna uymaktadır.";
                label1.ForeColor = Color.Green;
            }
            else
            {
                label1.Text = word+" kelimesi küçük ünlü uyumuna uymamaktadır.";
                label1.ForeColor = Color.Red;
            }
            if (kucukUnluCheck(unluler))
            {
                label2.Text = word+" kelimesi büyük ünlü uyumuna uymaktadır.";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = word+" kelimesi büyük ünlü uyumuna uymamaktadır.";
                label2.ForeColor = Color.Red;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }

        private void wordTxt_Enter(object sender, EventArgs e)
        {

        }

        private void wordTxt_Leave(object sender, EventArgs e)
        {

        }
    }
}
