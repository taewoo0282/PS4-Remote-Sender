using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace ps4RemoteSender
{
    public partial class PS4RemoteSender : Form
    {
        private static PS4RemoteSender _getinstance;

        public static PS4RemoteSender getinstance()
        {
            // 싱글톤 구현 하기.
            if (_getinstance == null)
            {
                _getinstance = new PS4RemoteSender();
            }
            return _getinstance;
        }

        public PS4RemoteSender()
        {
            InitializeComponent();
            prepare_comboBox();
        }

        public void prepare_comboBox()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                {
                   // if (nic.Description == comboBox1.SelectedItem.ToString())
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            comboBox1.Items.Add(ip.Address.ToString() + " :::::"+ nic.Description);
                        }
                    }
                }
            }

            comboBox1.SelectedIndex = 0;
        }

        private void pkgFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PKG Files|*.pkg";
            openFileDialog.Title = "패키지 파일 선택하세요.";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileNames.Length > 0)
                {
                    foreach (string filename in openFileDialog.FileNames)
                    {
                        this.fileOpenText.Text = filename;
                    }
                }
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
