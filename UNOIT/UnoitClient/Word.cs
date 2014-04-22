using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientBLL;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnoitClient
{
    public partial class Word : Form
    {
        private ClientBLL.UnoitServer.Entry entry;
        public Word(string entryName)
        {
            InitializeComponent();
            Text = "Unoit 2011 ----" + entryName;
            lblEntryName.Text = entryName;
            entry = ClientAgent.server.SearchEntryByName(entryName);
            txtContent.Text = entry.Content;
            //
            webBContent.DocumentText = entry.Content;
            lblUpSum.Text = entry.UpSum.ToString();
            lblDigSum.Text = entry.DigSum.ToString();
        }

        public Word(ClientBLL.UnoitServer.Entry entry)
        {
            InitializeComponent();
            this.entry = entry;
            Text = "Unoit 2011 ----" + entry.EntryName;
            lblEntryName.Text = entry.EntryName;
            txtContent.Text = entry.Content;
            webBContent.DocumentText = entry.Content;
            lblUpSum.Text = entry.UpSum.ToString();
            lblDigSum.Text = entry.DigSum.ToString();
        }

        private void imgUp_MouseLeave(object sender, EventArgs e)
        {
            imgUp2.BringToFront();
            this.Cursor = Cursors.Arrow;
        }

        private void imgDig2_MouseHover(object sender, EventArgs e)
        {
            imgDig.BringToFront();
            this.Cursor = Cursors.Hand;
        }

        private void imgUp2_MouseHover(object sender, EventArgs e)
        {
            imgUp.BringToFront();
            this.Cursor = Cursors.Hand;
        }

        private void imgDig_MouseLeave(object sender, EventArgs e)
        {
            imgDig2.BringToFront();
            this.Cursor = Cursors.Arrow;
        }

        private void imgUp_Click(object sender, EventArgs e)
        {
            if (ClientAgent.username != null)
            {
                if (ClientAgent.server.Support(lblEntryName.Text, ClientAgent.username))
                {
                    MessageBox.Show("评价成功！");
                    lblUpSum.Text = (int.Parse(lblUpSum.Text) + 1).ToString();
                }
                else
                {
                    MessageBox.Show("您已经评价过该词条！");
                }
            }
            else
            {
                MessageBox.Show("请先登录再评价！");
            }
        }

        private void imgDig_Click(object sender, EventArgs e)
        {
            if (ClientAgent.username != null)
            {
                if (ClientAgent.server.DisSupport(lblEntryName.Text, ClientAgent.username))
                {
                    MessageBox.Show("评价成功！");
                    lblDigSum.Text = (int.Parse(lblUpSum.Text) + 1).ToString();
                }
                else
                {
                    MessageBox.Show("您已经评价过该词条！");
                }
            }
            else
            {
                MessageBox.Show("请先登录再评价！");
            }
        }

        private void imgSave2_MouseHover(object sender, EventArgs e)
        {
            imgSave.BringToFront();
            this.Cursor = Cursors.Hand;
        }

        private void imgSave_MouseLeave(object sender, EventArgs e)
        {
            imgSave2.BringToFront();
            this.Cursor = Cursors.Arrow;
        }

        private void imgSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ClientBLL.UnoitServer.Entry> list = new List<ClientBLL.UnoitServer.Entry>();
                IFormatter serializer = new BinaryFormatter();
                FileStream saveFile = new FileStream("SavedWords.sharp", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if(saveFile.Length > 0)
                list = serializer.Deserialize(saveFile) as List<ClientBLL.UnoitServer.Entry>;
                list.Add(entry);
                serializer.Serialize(saveFile, list);
                saveFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lkEdit_Click(object sender, EventArgs e)
        {
            if (ClientAgent.username != null)
            {
                EditWord ew = new EditWord(this.entry);
                ew.Show();                
            }
            else
            {
                MessageBox.Show("请先登录再编辑！");
            }
        }
    }
}
