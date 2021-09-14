﻿using Minecraft_Mac.Forms;
using PluginsAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Mac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        _1_12_2 Form1_12_2 = new _1_12_2();
        All Form1_All = new All();

        private Form currentChildForm;
        private string currentChildFormname;
        public void OpenChildForm(Form childForm, bool newform = false)
        {
            if (currentChildForm != childForm && currentChildFormname != childForm.Name)
            {
                if (currentChildForm != null)
                {
                    if (newform)
                    {
                        currentChildForm.Close();
                    }
                    panelDesktop.Controls.Clear();
                }
                currentChildForm = childForm;
                currentChildFormname = childForm.Name;
                childForm.BackColor = panelDesktop.BackColor;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Add(childForm);
                panelDesktop.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string itemname = comboBox1.SelectedItem.ToString();

                switch (itemname)
                {
                    case "1.12.2":
                        OpenChildForm(Form1_12_2, false);
                        break;
                    case "All":
                        OpenChildForm(Form1_All, false);
                        break;
                }
            }
        }

        public static Bitmap BitmapFromURL(string url)
        {
            Bitmap loadedBitmap = null;
            try
            {
                var request = System.Net.WebRequest.Create(url);
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    loadedBitmap = new Bitmap(responseStream);
                }
            }
            catch (System.Net.WebException ex)
            {

            }
            return loadedBitmap;
        }

        public static Size GetTextSize(Control control)
        {
            Size len = TextRenderer.MeasureText(control.Text, control.Font);
            return len;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
