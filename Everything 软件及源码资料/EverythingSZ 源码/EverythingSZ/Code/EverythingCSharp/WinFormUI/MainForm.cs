using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QueryEngine;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace WinFormUI
{
    public partial class MainForm : Form
    {
        private List<FileAndDirectoryEntry> entries;

        private int allFilesCount;

        private string previousFilterString;

        public MainForm()
        {
            this.entries = null;
            this.allFilesCount = 0;

            InitializeComponent();
        }

        private string FilterString
        {
            get
            {
                return txtFilterString.Text.Trim().ToUpper();
            }
        }

        private void CheckAndSearch()
        {
            tInputChecker.Stop();

            if (!string.IsNullOrWhiteSpace(this.FilterString))
            {
                if (string.Compare(this.previousFilterString, this.FilterString, true) != 0)
                {
                    ShowSearchResult();
                }
            }
            else
            {
                ClearResult();
            }

            this.previousFilterString = this.FilterString;

            tInputChecker.Start();
        }

        private void ClearResult()
        {
            if (dgvResult.Rows.Count > 0)
            {
                statusLabel.Text = "Ready";

                dgvResult.DataSource = new List<FileAndDirectoryEntry>();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            statusLabel.Text = "Getting files information";

            this.entries = Engine.GetAllFilesAndDirectories();
            this.allFilesCount = entries.Count();

            statusLabel.Text = "Ready";

            txtFilterString.Enabled = true;
            txtFilterString.Focus();

            tInputChecker.Start();
        }

        private void ShowSearchResult()
        {
            string filterString = this.FilterString;

            var filteredResult = this.entries
                    .Where(f => f.FileName.ToUpper().Contains(filterString))
                    .OrderBy(f => f.FileName)
                    .ToList();

            dgvResult.DataSource = filteredResult;

            int fileCount = filteredResult.Count();

            statusLabel.Text = string.Format("{0} files found in {1} files", fileCount, allFilesCount);
        }

        private void tInputChecker_Tick(object sender, EventArgs e)
        {
            CheckAndSearch();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtFilterString.Text = string.Empty;
            txtFilterString.Enabled = false;

            dgvResult.AutoGenerateColumns = false;
        }

        private void miOpenFileLocation_Click(object sender, EventArgs e)
        {
            OpenFileLocationBySelectedRow();
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFileLocationBySelectedRow();
        }

        private void OpenFileLocationBySelectedRow()
        {
            if (dgvResult.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvResult.SelectedRows[0];

                var dataItem = selectedRow.DataBoundItem as FileAndDirectoryEntry;

                OpenFileLocation(dataItem);
            }
        }

        private static void OpenFileLocation(FileAndDirectoryEntry fileAndDirectoryEntry)
        {
            if (File.Exists(fileAndDirectoryEntry.FullFileName))
            {
                Process.Start("explorer.exe", "/select, " + fileAndDirectoryEntry.FullFileName);
            }
        }

        private void dgvResult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvResult.ClearSelection();

                dgvResult.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
