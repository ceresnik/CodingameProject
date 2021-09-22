using System.IO;
using System.Threading.Tasks;
using System.Windows;


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
            await SearchFreezingWayAsync(this.lblChoosedDirectory.Content.ToString());
            //await SearchNotFreezingWayAsync(this.lblChoosedDirectory.Content.ToString());
            System.Windows.Forms.MessageBox.Show(@"After copy.");
        }

        private static async Task SearchNotFreezingWayAsync(string directory)
        {
            await Task.Run(() =>
            {
                var files = Directory.GetFiles(directory);
                foreach (string fileName in files)
                {
                    var fileContent = File.ReadAllText(fileName);
                    var path = Path.Combine(@"C:\CopyFilesHere", Path.GetFileName(fileName));
                    using (var streamWriter = new StreamWriter(path))
                    {
                        streamWriter.Write(fileContent);
                    }
                }
            });
        }

        private static async Task SearchFreezingWayAsync(string directory)
        {
            var files = Directory.GetFiles(directory);
            foreach (string fileName in files)
            {
                var fileContent = File.ReadAllText(fileName);
                var path = Path.Combine(@"C:\CopyFilesHere", Path.GetFileName(fileName));
                using (var streamWriter = new StreamWriter(path))
                {
                    await streamWriter.WriteAsync(fileContent);
                }
            }
        }

        private void btnCopySynchronous_Click(object sender, RoutedEventArgs e)
        {
            SearchFreezingWay(this.lblChoosedDirectory.Content.ToString());
            System.Windows.Forms.MessageBox.Show(@"After copy.");
        }

        private static void SearchFreezingWay(string directory)
        {
            var files = Directory.GetFiles(directory);
            foreach (string fileName in files)
            {
                var fileContent = File.ReadAllText(fileName);
                var path = Path.Combine(@"C:\CopyFilesHere", Path.GetFileName(fileName));
                using (var streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write(fileContent);
                }
            }
        }

    }
}
