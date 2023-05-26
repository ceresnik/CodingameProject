using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;


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

        private async void btnCopyAsynchronous_Click(object sender, RoutedEventArgs e)
        {
            //Task<bool> task = SearchFreezingWayWithAwait(this.lblChoosedDirectory.Content.ToString());
            Task<bool> task = SearchNotFreezingWayAsync(this.lblChoosedDirectory.Content.ToString());
            MessageBox.Show("Now I'm here.");
            MessageBox.Show(await task
                ? @"After copy."
                : @"Copy was not successful.");
        }

        private static async Task<bool> SearchNotFreezingWayAsync(string directory)
        {
            bool result = true;
            await Task.Run(() =>
            {
                var files = Directory.GetFiles(directory);
                foreach (string fileName in files)
                {
                    var fileContent = File.ReadAllText(fileName);
                    var path = Path.Combine(@"C:\CopyFilesHere", Path.GetFileName(fileName));
                    try
                    {
                        using (var streamWriter = new StreamWriter(path))
                        {
                            streamWriter.Write(fileContent);
                        }
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine($"Not able to copy, as the directory {path} was not found.");
                        result = false;
                        break;
                    }

                    Thread.Sleep(500);
                }
            });
            return result;
        }

        private static async Task<bool> SearchFreezingWayWithAwait(string directory)
        {
            var files = Directory.GetFiles(directory);
            bool result = true;
            foreach (string fileName in files)
            {
                var fileContent = File.ReadAllText(fileName);
                var path = Path.Combine(@"C:\CopyFilesHere", Path.GetFileName(fileName));
                try
                {
                    using (var streamWriter = new StreamWriter(path))
                    {
                        await streamWriter.WriteAsync(fileContent);
                    }
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine($"Not able to copy, as the directory {path} was not found.");
                    result = false;
                    break;
                }

                Thread.Sleep(500);
            }

            return result;
        }

        private void btnCopySynchronous_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SearchFreezingWay(this.lblChoosedDirectory.Content.ToString())
                ? @"After copy."
                : @"Copy was not successful.");
        }

        private static bool SearchFreezingWay(string directory)
        {
            var files = Directory.GetFiles(directory);
            bool result = true;
            foreach (string fileName in files)
            {
                var fileContent = File.ReadAllText(fileName);
                var path = Path.Combine(@"C:\CopyFilesHere", Path.GetFileName(fileName));
                try
                {
                    using (var streamWriter = new StreamWriter(path))
                    {
                        streamWriter.Write(fileContent);
                    }
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine($"Not able to copy, as the directory {path} was not found.");
                    result = false;
                    break;
                }

                Thread.Sleep(500);
            }

            return result;
        }
    }
}
