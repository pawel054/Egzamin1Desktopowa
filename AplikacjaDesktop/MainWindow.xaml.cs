using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<AlbumObject> albumObjects = new List<AlbumObject>();
        public static int currentIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromFile(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Data.txt"));
            DisplayData(currentIndex);
        }

        private void PreviousButtonClicked(object sender, RoutedEventArgs e)
        {
            if(currentIndex <= 0)
            {
                currentIndex = albumObjects.Count - 1;
                DisplayData(currentIndex);
            }
            else
            {
                currentIndex--;
                DisplayData(currentIndex);
            }
        }

        private void NextButtonClicked(object sender, RoutedEventArgs e)
        {
            if(currentIndex < albumObjects.Count-1)
            {
                currentIndex++;
                DisplayData(currentIndex);
            }
            else
            {
                currentIndex = 0;
                DisplayData(currentIndex);
            }
        }

        private void DisplayData(int index)
        {
            AlbumObject albumObject = albumObjects[index];
            ArtistLabel.Content = albumObject.Artist;
            AlbumLabel.Content = albumObject.Album;
            songsLabel.Content = albumObject.SongsNumber + " utworów";
            yearLabel.Content = albumObject.Year;
        }

        private static void LoadDataFromFile(string filePath)
        {
            List<string> data = new List<string>();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        data.Add(line);
                    }
                }

                for (int i = 0; i < data.Count; i += 5)
                {
                    AlbumObject album = new AlbumObject
                    {
                        Artist = data[i],
                        Album = data[i + 1],
                        SongsNumber = int.Parse(data[i + 2]),
                        Year = int.Parse(data[i + 3]),
                        DownloadNumber = int.Parse(data[i + 4])
                    };

                    albumObjects.Add(album);
                }
            }
        }
    }
}