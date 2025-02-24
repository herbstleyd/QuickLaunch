using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace QuickLaunch
{

    public partial class MainForm : Form
    {
        private List<QuickLaunchItem> quickLaunchItems = new List<QuickLaunchItem>();
        private const string SaveFilePath = "quicklaunchitems.xml";

        public MainForm()
        {
            InitializeComponent();
            LoadQuickLaunchItems();
        }

        private void LoadQuickLaunchItems()
        {
            if (File.Exists(SaveFilePath))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<QuickLaunchItem>));
                    using (FileStream fs = new FileStream(SaveFilePath, FileMode.Open))
                    {
                        quickLaunchItems = (List<QuickLaunchItem>)serializer.Deserialize(fs);
                    }
                    DisplayQuickLaunchItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Laden der QuickLaunch-Items: {ex.Message}");
                }
            }
        }

        private void SaveQuickLaunchItems()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuickLaunchItem>));
            using (FileStream fs = new FileStream(SaveFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, quickLaunchItems);
            }
        }

        private void AddProgramButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Programme (*.exe)|*.exe",
                Title = "Programm hinzufügen"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                QuickLaunchItem item = new QuickLaunchItem
                {
                    FilePath = filePath,
                    FileName = fileName
                };
                quickLaunchItems.Add(item);
                DisplayQuickLaunchItems();
            }
        }

        private void RemoveProgramButton_Click(object sender, EventArgs e, QuickLaunchItem item)
        {
            quickLaunchItems.Remove(item);
            DisplayQuickLaunchItems();
        }

        private void DisplayQuickLaunchItems()
        {
            flowLayoutPanel.Controls.Clear();
            foreach (var item in quickLaunchItems)
            {
                FlowLayoutPanel itemPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = flowLayoutPanel.ClientSize.Width - 25, // Platz für Scrollbar
                    Height = 30 // Kleinere Höhe
                };
                Button programButton = new Button
                {
                    Text = item.FileName,
                    Width = 100, // Kleinere Breite
                    Height = 30 // Kleinere Höhe
                };
                programButton.Click += (s, e) => System.Diagnostics.Process.Start(item.FilePath);
                Button removeButton = new Button
                {
                    Text = "Löschen",
                    Width = 60,
                    Height = 30
                };
                removeButton.Click += (s, e) => RemoveProgramButton_Click(s, e, item);
                itemPanel.Controls.Add(programButton);
                itemPanel.Controls.Add(removeButton);
                flowLayoutPanel.Controls.Add(itemPanel);
                // Trennlinie hinzufügen
                Label separator = new Label
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Height = 2,
                    Width = flowLayoutPanel.ClientSize.Width - 25
                };
                flowLayoutPanel.Controls.Add(separator);
            }
            flowLayoutPanel.PerformLayout(); // Layout aktualisieren
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveQuickLaunchItems();
        }
    }

    [Serializable]
    public class QuickLaunchItem
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}