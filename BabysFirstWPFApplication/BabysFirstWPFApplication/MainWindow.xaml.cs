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

        public List<MySprite> temp = new List<MySprite>();
        
        string dataBound {get; set;} 
        bool Confirm = false;

       
        
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            

            

            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Confirm = true;
            Console.WriteLine("click");
            if (Confirm)
            {
                dataBound = "dame";
            }

        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog LoadedFile = new Microsoft.Win32.OpenFileDialog();
         
            LoadedFile.DefaultExt = ".png"; // default file extension
            LoadedFile.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
           
            
            Nullable<bool> IsFileThere = LoadedFile.ShowDialog();
            if (IsFileThere == true)
            {
               //temp.Add(new MySprite(new BitmapImage(new Uri(LoadedFile.FileName))));
                temp.Add(new MySprite(LoadedFile.FileName));
                MySprite tempname1 = new MySprite(new Uri(LoadedFile.FileName));

                Image tempImage = new Image();
                Screen.Children.Add();
                //tempImage.Source = tempname1.spriteImage;
               // Canvas.SetLeft(tempImage, 0);
               // Canvas.SetTop(tempImage, 0);
                
            }

            Console.WriteLine("Sprite Count " + temp.Count);
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
       
    }
    


    public class MySprite
    {
        public MySprite(Uri temp) 
        {
            spriteImage = new BitmapImage(temp);
        }

        public MySprite(string imagePath)
        {
            BitmapImage sprite = new BitmapImage(new Uri(imagePath));

            spriteImage = sprite;
        }
        private int width;
        private int height;
        private float x;
        private float y;

        public BitmapImage spriteImage;
        
        private string fileName;
    }
    
   
    
    public class Image : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
            get
            {
                return name;
            }
        }

        private int age;
        public int Age
        {
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
            get
            {
                return age;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
