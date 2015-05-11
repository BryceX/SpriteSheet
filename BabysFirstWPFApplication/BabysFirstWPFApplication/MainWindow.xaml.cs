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
using System.Drawing;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;


namespace BabysFirstWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        //public List<Image> imageList = new List<Image>();
        public ObservableCollection<MySprite> spriteList = new ObservableCollection<MySprite>();
        string dataBound {get; set;} 
        bool Confirm = false;
        
       
        
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            TheBox.ItemsSource = spriteList;

        }
      
        public void SaveGif()
        { 
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Confirm = true;
            Console.WriteLine("click");
            if (Confirm)
            {
                dataBound = "done";
            }

        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog LoadedFile = new Microsoft.Win32.OpenFileDialog();
           
            LoadedFile.DefaultExt = ".png"; // default file extension
            LoadedFile.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
           
            
            Nullable<bool> IsFileThere = LoadedFile.ShowDialog();
            if (IsFileThere == true)
            {
                //Screen.Children.Clear();
                MySprite spriteName = new MySprite(LoadedFile.FileName);
            
                spriteList.Add(spriteName);

                ClearCanvas();


                

               

                
            }

           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        { 
            MySprite selectedSprite = TheBox.SelectedItem as MySprite;
            if (selectedSprite !=null)
            {
            
                spriteList.Remove(selectedSprite);
                ClearCanvas();
            

                
            }
        }
       
        public void ClearCanvas()
        {
            Screen.Children.Clear();
            int xPos = 0;
            int height = 0;
            for (int i = 0; i < spriteList.Count; i++)
            {
                Screen.Children.Add(spriteList[i].spriteImage);
                Canvas.SetLeft(spriteList[i].spriteImage, xPos);

                xPos += (int)spriteList[i].spriteBitmapImage.Width;
                if ((int)spriteList[i].spriteBitmapImage.Height > height)
                {
                    height = (int)spriteList[i].spriteBitmapImage.Height;
                }
            }
            Screen.Width = xPos;
            Screen.Height = height;
        }
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            
            Microsoft.Win32.SaveFileDialog savedFile = new Microsoft.Win32.SaveFileDialog();
            
            if (savedFile.ShowDialog() == true)
            {
                Size screenSize = new Size(Screen.Width, Screen.Height);
                Screen.Measure(screenSize);
                Screen.Arrange(new Rect(screenSize));
                Rect temp = new Rect(Screen.RenderSize);
                // Build the final image
                RenderTargetBitmap tempImage = new RenderTargetBitmap((int)temp.Right, (int)temp.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                tempImage.Render(Screen);
                BitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(tempImage));

                // OPen a stream to the desired file 
               
                // Save to the stream
                System.IO.MemoryStream imageStream = new System.IO.MemoryStream();
                png.Save(imageStream);
                //Save(savedFile.FileName);
                // Close the stream
                imageStream.Close();
                System.IO.File.WriteAllBytes(savedFile.FileName, imageStream.ToArray());
                Console.WriteLine("Completed");
            
            }

            //try
            //{
            //    if (savedFile != null)
            //    {
            //        
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("There was a problem saving the file." +
            //        "Check the file permissions.");
            //}

           
        }

       

        
    }
    


    public class MySprite : INotifyPropertyChanged
    {

        public MySprite(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
            Image sprite = new Image();

            spriteBitmapImage = bitmap;
            spriteImage = sprite;

            spriteImage.Source = bitmap;

            FileName = System.IO.Path.GetFileName( imagePath );
        }
        private int width;
        public int Width 
        {
            get 
            {
                return width;
            }
            set 
            {
                if (width != value)
                {
                    width = value;
                    NotifyPropertyChanged("Width");
                }
            }
        }
        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (height != value)
                {
                    height = value;
                    NotifyPropertyChanged("Width");
                }
            }
        }
        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (x != value)
                {
                    x = value;
                    NotifyPropertyChanged("Width");
                }
            }
        }
        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (y != value)
                {
                    y = value;
                    NotifyPropertyChanged("Width");
                }
            }
        }

        public BitmapImage spriteBitmapImage;
        public Image spriteImage;
        
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    NotifyPropertyChanged("FileName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
   
    
   
}
