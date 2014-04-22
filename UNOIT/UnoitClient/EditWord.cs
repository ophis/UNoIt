using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientBLL;

namespace UnoitClient
{
    public partial class EditWord : Form
    {
        public ClientBLL.UnoitServer.Entry entry;
        public EditWord(ClientBLL.UnoitServer.Entry entry)
        {
            InitializeComponent();
            this.entry = entry;
            lblEntryName.Text = entry.EntryName;
            txtContent.Text = entry.Content;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtContent.Text == entry.Content)
            {
                MessageBox.Show("无任何修改");
            }
            else {
                ClientBLL.UnoitServer.EntryToBeVerified newEntry = new ClientBLL.UnoitServer.EntryToBeVerified();
                newEntry.CatagoryId = entry.CatagoryId;
                newEntry.Content = txtContent.Text;
                newEntry.EntryName = entry.EntryName;
                newEntry.ReleasedTime = DateTime.Now;
                newEntry.Source = entry.Source;
                newEntry.UserId = ClientAgent.server.GetUserIdByName(ClientAgent.username);
                ClientAgent.server.EditEntry(newEntry);
                MessageBox.Show("提交成功，等待审核");
            }
        }
    }
}
