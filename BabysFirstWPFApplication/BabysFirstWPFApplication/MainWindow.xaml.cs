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

using System.Collections.ObjectModel;
using System.ComponentModel;

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
        int xPos = 0;
       
        
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            TheBox.ItemsSource = spriteList;

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
                MySprite spriteName = new MySprite( LoadedFile.FileName );
                spriteList.Add(spriteName);
                
                Screen.Children.Add(spriteName.spriteImage);
                
                
                
                
                
                Canvas.SetLeft(spriteName.spriteImage, xPos);

                


               ////temp.Add(new MySprite(new BitmapImage(new Uri(LoadedFile.FileName)))); butts
               // temp.Add(new MySprite(LoadedFile.FileName));
                
               // MySprite tempname1 = new MySprite(new Uri(LoadedFile.FileName));
                
               
               // sprite.Source = tempname1.spriteImage;
               // //tempImage.Source = tempname1.spriteImage;
               // Canvas.SetLeft(sprite, (double)0.0);
               // Canvas.SetTop(sprite, (double)0.0);

                xPos += (int)spriteName.spriteBitmapImage.Width;
            }

            Console.WriteLine("Sprite Count" + spriteList.Count);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MySprite selectedSprite = TheBox.SelectedItem as MySprite;
            Screen.Children.Remove(selectedSprite.spriteImage);
            spriteList.Remove(selectedSprite);
          
        }
       

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

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
        private float x;
        private float y;

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
