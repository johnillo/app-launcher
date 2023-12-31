using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace AppLauncher
{
    [Serializable]
    public partial class MainForm : Form
    {
        SortedDictionary<String, String> linksList;

        public MainForm()
        {
            InitializeComponent();
            linksList = LoadStartMenuLinks();
        }

        private SortedDictionary<String, String> LoadStartMenuLinks()
        {
            SortedDictionary<String, String> dictionary = new SortedDictionary<String, String>();

            String[] links = Utils.MergeArrays(
                ExtractLinks(Program.GetAllUsersStartMenuDirectory()),
                ExtractLinks(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)));

            foreach (String p in links) {
                String filename = Path.GetFileNameWithoutExtension(p);
                if (dictionary.ContainsKey(filename)) {
                    continue;
                }
                dictionary.Add(filename, p);
            }

            return dictionary;
        }

        private String[] ExtractLinks(String path)
        {
            return ExtractLinksRecursive(path, new String[0]);
        }

        private String[] ExtractLinksRecursive(String path, String[] files)
        {
            String[] pathFiles = Directory.GetFiles(path, "*.lnk");

            pathFiles = Utils.MergeArrays(pathFiles, files);

            String[] pathDirs = Directory.GetDirectories(path);

            foreach (String dir in pathDirs) {
                String[] dirFilePaths = ExtractLinksRecursive(dir, files);
                if (dirFilePaths.Length > 0) {
                    pathFiles = Utils.MergeArrays(pathFiles, dirFilePaths);
                }
            }

            return pathFiles;
        }

        private void FilterLinks(String keyword)
        {
            SortedDictionary<String, String> filteredData = new SortedDictionary<String, String>();

            foreach (KeyValuePair<String, String> val in linksList) {
                Boolean containsUninstallWord = val.Key.ToLowerInvariant().Contains("uninstall");
                if (containsUninstallWord && ExcludeUninstallersCheckbox.Checked) {
                    continue;
                }
                if (val.Key.ToLowerInvariant().Contains(keyword.ToLowerInvariant())) {
                    filteredData.Add(val.Key, val.Value);
                }
            }

            if (filteredData.Count == 0) {
                appsList.DataSource = null;
                return;
            }

            appsList.DataSource = new BindingSource(filteredData, null);
            appsList.DisplayMember = "Key";
            appsList.ValueMember = "Value";
        }

        private void ExecuteSelectedLink()
        {
            String path = appsList.SelectedValue.ToString();
            try {
                Process.Start(path);
                Application.Exit();
            } catch {
                MessageBox.Show("Failed to run application.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSettings()
        {
            Size = Properties.Settings.Default.WindowSize;
            Location = Properties.Settings.Default.WindowLocation;
            searchbox.Text = Properties.Settings.Default.LastSearchString;
            
            // make sure window is within all screen bounds
            foreach (Screen screen in Screen.AllScreens) {
                if (screen.WorkingArea.Contains(Location)) {
                    return;
                }
            }
            CenterToScreen();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.WindowSize = Size;
            Properties.Settings.Default.WindowLocation = Location;
            Properties.Settings.Default.LastSearchString = searchbox.Text;

            Properties.Settings.Default.Save();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            FilterLinks(searchbox.Text);
            LoadSettings();
        }

        private void OnSearchBoxTextChanged(object sender, EventArgs e)
        {
            FilterLinks(((TextBox)sender).Text);
        }

        private void OnMainFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                e.SuppressKeyPress = true;
                Application.Exit();
            }
        }

        private void OnSearchBoxKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.A:
                    Console.WriteLine(e.Modifiers);
                    if (e.Modifiers == Keys.Control) {
                        ((TextBox)sender).SelectAll();
                        e.SuppressKeyPress = true;
                    }
                    break;
                case Keys.Enter:
                    if (appsList.SelectedItems.Count == 0) {
                        return;
                    }
                    ExecuteSelectedLink();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Down:
                    if (appsList.SelectedItems.Count == 0) {
                        return;
                    }
                    appsList.SelectedIndex = Math.Min(appsList.SelectedIndex + 1, appsList.Items.Count - 1);
                    e.Handled = true;
                    break;
                case Keys.Up:
                    if (appsList.SelectedItems.Count == 0) {
                        return;
                    }
                    appsList.SelectedIndex = Math.Max(appsList.SelectedIndex - 1, 0);
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void OnLaunchActionClick(object sender, EventArgs e)
        {
            ExecuteSelectedLink();
        }

        private void OnExcludeUninstallersCheckboxCheckChanged(object sender, EventArgs e)
        {
            FilterLinks(searchbox.Text);
        }

        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void OnAppListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                ExecuteSelectedLink();
            }
        }

        private void OnAppListMouseDblClick(object sender, MouseEventArgs e)
        {
            ExecuteSelectedLink();
        }
    }
}