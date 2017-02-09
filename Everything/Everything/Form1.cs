using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Everything
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileSystemWatcher _watcher = new FileSystemWatcher(@"J:\", "*.*");
            _watcher.Created += new FileSystemEventHandler(OnProcess);
            _watcher.Changed += new FileSystemEventHandler(OnProcess);
            _watcher.Deleted += new FileSystemEventHandler(OnProcess);
            _watcher.Renamed += new RenamedEventHandler(OnFileRenamed);
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        private void OnProcess(object sender, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed: break;
                case WatcherChangeTypes.Created: break;
                case WatcherChangeTypes.Deleted: break;
            }
            Print(e.ChangeType + " : " + e.FullPath);
        }
        
        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            Print("Rename : " + e.OldFullPath + " > " + e.FullPath);
        }

        private void Print(string s)
        {
            BeginInvoke(new Action(() =>
            {
                textBox1.Text += s + Environment.NewLine;
            }));
        }
    }
}
