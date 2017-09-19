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
using Y.FileQueryEngine.QueryEngine;
using Y.FileQueryEngine.UsnOperation;

namespace Everything.Views
{
    public partial class MainForm : Form
    {
        long LastUsn = 0;
        ulong LastFrn = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //获取所有NTFS磁盘
            var drives = FileQueryEngine.GetReadyNtfsDrives();
            CBDrives.Items.AddRange(drives.ToArray());
            CBDrives.SelectedIndex = 0;
        }

        private void BTFind_Click(object sender, EventArgs e)
        {
            //获取上次Usn
            long.TryParse(TBLastUsn.Text, out LastUsn);
            //获取上次FileRefNumber
            ulong.TryParse(TBLastFrn.Text, out LastFrn);

            if (CBDrives.SelectedItem != null)
                using (UsnOperator uo = new UsnOperator((DriveInfo)CBDrives.SelectedItem))
                {
                    uo.GetEntries(LastUsn, LastFrn, ShowEntries, 3);
                }
        }
        private void BTLine_Click(object sender, EventArgs e)
        {
            TBResult.AppendText(new string('-', 50));
            TBResult.AppendText(Environment.NewLine);
        }
        private void ShowEntries(DriveInfo drive, List<UsnEntry> data)
        {
            if (data != null && data.Count() > 0)
            {
                foreach (var d in data)
                {
                    TBResult.AppendText(string.Format("{0}\t\t{1}\t\t{2}", d.Usn, d.FileReferenceNumber, d.FileName));
                    TBResult.AppendText(Environment.NewLine);
                }
            }
        }
        #region TextBox 输入验证
        private void TBLastUsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void TBLastFrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        #endregion


    }
}
