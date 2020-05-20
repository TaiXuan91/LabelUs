using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabelUs
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

        private void openImage_Click(object sender, RoutedEventArgs e)
        {
            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 600;

            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // Get image file path
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "PNG Image (.png)|*.png"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            string filename="";
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
            }
            else {
                Console.WriteLine("Can't get image file path");
            }

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            //myBitmapImage.UriSource = new Uri(@"C:\Users\Administrator.000\Pictures\总体直方图.png");
            myBitmapImage.UriSource = new Uri(filename);

            // To save significant application memory, set the DecodePixelWidth or
            // DecodePixelHeight of the BitmapImage value of the image source to the desired
            // height or width of the rendered image. If you don't do this, the application will
            // cache the image as though it were rendered as its normal size rather then just
            // the size that is displayed.
            // Note: In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 600;
            myBitmapImage.EndInit();
            //set image source
            myImage.Source = myBitmapImage;
            this.imageBox.Source = myBitmapImage;
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

//Source=