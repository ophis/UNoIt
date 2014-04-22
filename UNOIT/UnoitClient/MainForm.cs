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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            button1.SendToBack();
            dtGridViewResult.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dtGridViewResult.RowsDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("搜索内容不能为空");
            }
            else
            {
                List<ClientBLL.UnoitServer.Entry> list = ClientAgent.Search(txtSearch.Text);
                dtGridViewResult.DataSource = list;
                foreach (DataGridViewColumn col in dtGridViewResult.Columns)
                {
                    //if (col.DisplayIndex > 3)
                    col.Visible = false;
                }
                dtGridViewResult.Columns["EntryName"].DisplayIndex = 0;
                dtGridViewResult.Columns["EntryName"].HeaderText = "词条";
                dtGridViewResult.Columns["EntryName"].Visible = true;

                dtGridViewResult.Columns["Content"].DisplayIndex = 1;
                dtGridViewResult.Columns["Content"].HeaderText = "内容";
                dtGridViewResult.Columns["Content"].Width = 280;
                dtGridViewResult.Columns["Content"].Visible = true;

                dtGridViewResult.Columns["UpSum"].DisplayIndex = 2;
                dtGridViewResult.Columns["UpSum"].HeaderText = "赞";
                dtGridViewResult.Columns["UpSum"].Width = 30;
                dtGridViewResult.Columns["UpSum"].Visible = true;

                dtGridViewResult.Columns["DigSum"].DisplayIndex = 3;
                dtGridViewResult.Columns["DigSum"].HeaderText = "踩";
                dtGridViewResult.Columns["DigSum"].Width = 30;
                dtGridViewResult.Columns["DigSum"].Visible = true;

                dtGridViewResult.Columns["ReleasedTime"].DisplayIndex = 4;
                dtGridViewResult.Columns["ReleasedTime"].HeaderText = "发布时间";
                dtGridViewResult.Columns["ReleasedTime"].Width = 100;
                dtGridViewResult.Columns["ReleasedTime"].Visible = true;
                OnlineSearchFlag = true;
                
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
        }

        private void dtGridViewResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OnlineSearchFlag)
            {
                string entryName = dtGridViewResult.Rows[e.RowIndex].Cells["EntryName"].Value.ToString();
                Word w = new Word(entryName);
                w.Show();
            }
            else 
            {
                List<ClientBLL.UnoitServer.Entry> list = dtGridViewResult.DataSource as List<ClientBLL.UnoitServer.Entry>;
                ClientBLL.UnoitServer.Entry entry =  list[e.RowIndex];
                Word w = new Word(entry);
                w.Show();
            }
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lkLogin.Visible = false;
            Login log = new Login();
            log.Logged += new EventHandler(setUserName);
            log.Show();
        }

        private void setUserName(object sender, EventArgs e)
        {
            if (ClientAgent.username != null && ClientAgent.username != "")
            {
                //lkLogin.Visible = false;
                lblUserName.Text = "欢迎你：" + ClientAgent.username;
            }
            else 
            {
                lkLogin.Visible = true;
            }
        }

        private bool OnlineSearchFlag = true;
        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FileStream loadFile = new FileStream("SavedWords.sharp", FileMode.Open, FileAccess.Read);
            IFormatter serializer = new BinaryFormatter();
            //List<ClientBLL.UnoitServer.Entry> list = serializer.Deserialize(loadFile) as List<ClientBLL.UnoitServer.Entry>;
            List<ClientBLL.UnoitServer.Entry> list = (List<ClientBLL.UnoitServer.Entry>)serializer.Deserialize(loadFile);
            loadFile.Flush();
            if (list == null)
            {
                MessageBox.Show("无本地记录");
                return;
            }
            dtGridViewResult.DataSource = list;
            foreach (DataGridViewColumn col in dtGridViewResult.Columns)
            {
                //if (col.DisplayIndex > 3)
                col.Visible = false;
            }
            dtGridViewResult.Columns["EntryName"].DisplayIndex = 0;
            dtGridViewResult.Columns["EntryName"].HeaderText = "词条";
            dtGridViewResult.Columns["EntryName"].Visible = true;

            dtGridViewResult.Columns["Content"].DisplayIndex = 1;
            dtGridViewResult.Columns["Content"].HeaderText = "内容";
            dtGridViewResult.Columns["Content"].Width = 280;
            dtGridViewResult.Columns["Content"].Visible = true;

            dtGridViewResult.Columns["UpSum"].DisplayIndex = 2;
            dtGridViewResult.Columns["UpSum"].HeaderText = "赞";
            dtGridViewResult.Columns["UpSum"].Width = 30;
            dtGridViewResult.Columns["UpSum"].Visible = true;

            dtGridViewResult.Columns["DigSum"].DisplayIndex = 3;
            dtGridViewResult.Columns["DigSum"].HeaderText = "踩";
            dtGridViewResult.Columns["DigSum"].Width = 30;
            dtGridViewResult.Columns["DigSum"].Visible = true;

            dtGridViewResult.Columns["ReleasedTime"].DisplayIndex = 4;
            dtGridViewResult.Columns["ReleasedTime"].HeaderText = "发布时间";
            dtGridViewResult.Columns["ReleasedTime"].Width = 100;
            dtGridViewResult.Columns["ReleasedTime"].Visible = true;
            loadFile.Close();
            OnlineSearchFlag = false;
        }
    }
}
