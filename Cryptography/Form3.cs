using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptography
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        PlayFairEncryption pfe = new PlayFairEncryption();
        PlayFairDecryption pfd = new PlayFairDecryption();
        public void print() 
        {
        
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String a = pfe.PFEncryption(textBox1.Text.ToLower(), richTextBox1.Text.ToLower());
            listBox1.Items.Clear();
            richTextBox2.Text = a;
            listBox1.Items.Clear();

            List<string> steps = pfe.getStep();
            for (int i = 0; i < steps.Count; i++)
            {
                listBox1.Items.Add(steps[i]);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String a = pfd.PFDecryption(textBox1.Text.ToLower(), richTextBox1.Text.ToLower());

            richTextBox2.Text = a;
            listBox1.Items.Clear();
            List<string> steps = pfd.getStep();
            for (int i = 0; i < steps.Count; i++)
            {
                listBox1.Items.Add(steps[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

       

        
    }
}
