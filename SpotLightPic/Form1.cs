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

namespace SpotLightPic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var username = Environment.UserName;

            var picdir =String.Format(@"C:\Users\{0}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets", username);

            foreach(var f in Directory.EnumerateFiles(picdir))
            {
                var fi = new FileInfo(f);
                listView1.Items.Add(
                    new ListViewItem { Text = fi.Name,Tag=f }
                    );
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(ListViewItem item in listView1.Items)
                {
                    var dest_name = folderBrowserDialog1.SelectedPath + @"\" + item.Text + ".jpg";

                    var src_name = item.Tag.ToString();

                    File.Copy(src_name, dest_name);
                }

                MessageBox.Show("拷贝成功！");
            }
        }
    }
}
