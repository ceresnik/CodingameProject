using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace FindFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (string.IsNullOrWhiteSpace(fbd.SelectedPath) == false)
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    lblChoosedDirectory.Content = fbd.SelectedPath;
                    System.Windows.Forms.MessageBox.Show($@"Files found: " + files.Length, "Message");
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchFreezingWay(this.lblChoosedDirectory.Content.ToString());
            System.Windows.Forms.MessageBox.Show(@"After copy.");
        }

        private void SearchFreezingWay(string directory)
        {
            var files = Directory.GetFiles(directory);
            //List<string> fileNames = new List<string>();
            foreach (string fileName in files)
            {
                //fileNames.Add(fileName);
                var fileContent = File.ReadAllText(fileName);
                var path = Path.Combine(@"C:\CopyFilesHere", Path.GetFileName(fileName));
                using (var streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write(fileContent);
                }
            }

            //string fileNamesWithNewLine = string.Join(Environment.NewLine, fileNames);
            //System.Windows.Forms.MessageBox.Show(fileNamesWithNewLine);
        }
    }
}
