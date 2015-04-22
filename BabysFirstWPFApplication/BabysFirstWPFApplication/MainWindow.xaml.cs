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

        string dataBound {get; set;} 
        bool Confirm = false;

        public ObservableCollection<User> myList;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            myList = new ObservableCollection<User>();
            myList.Add(new User() { Name = "FileName" });

            listView.ItemsSource = myList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Confirm = true;
            Console.WriteLine("click");
            if (Confirm)
            {
                //HelloWorldBox.Text = "3 + 4 = ?";
                dataBound = "dame";
            }

        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            myList.Add(new User() { Name = "FileName"});
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
       
    }

    public class User : INotifyPropertyChanged
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
