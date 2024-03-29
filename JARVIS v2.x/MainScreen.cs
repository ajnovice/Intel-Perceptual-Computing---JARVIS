﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jarvis
{
    public partial class MainScreen : Form
    {
        private PXCMSession session;
        private MainFormGR GR;
        private MainFormVR VR;
        public bool gestureMouse = false;

        public MainScreen(PXCMSession session)
        {
            this.session = session;
            InitializeComponent();
        }

        public void binding(MainFormGR GR, MainFormVR VR)
        {
            this.GR = GR;
            this.VR = VR;
        }

        public void update_mouse_data(Point p)
        {
            try
            {
                this.label2.Text = "Mouse X : " + p.X;
                this.label3.Text = "Mouse Y : " + p.Y;
            }
            catch (Exception e)
            {
                this.label4.ForeColor = Color.Red;
                this.label4.Text = "x" + e.Message;
            }
        }

        private void MainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            this.label2.Text = "Mouse X : " + Control.MousePosition.X.ToString();
            this.label3.Text = "Mouse Y : " + Control.MousePosition.Y.ToString();
        }

        private void MainScreen_MouseClick(object sender, MouseEventArgs e)
        {
            this.label2.Text = "Mouse X : " + Control.MousePosition.X.ToString();
            this.label3.Text = "Mouse Y : " + Control.MousePosition.Y.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (VR.stop == false)
                    VR.Invoke(new Action(delegate { VR.stop = true; }));
                if (GR.stop == false)
                    GR.Invoke(new Action(delegate { GR.stop = true; }));
            }
            catch (Exception i)
            {
                VR.stop = true;
                GR.stop = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GR.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VR.ShowDialog(this);
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        protected override void OnClosed(EventArgs e)
        {
            button3_Click(this, new EventArgs());

            GR.Dispose();
            VR.Dispose();
            base.OnClosed(e);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            VR.Start_Click(this, new EventArgs());
            GR.Start_Click(this, new EventArgs());
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gestureMouse = !gestureMouse;
        }
        
    }
}