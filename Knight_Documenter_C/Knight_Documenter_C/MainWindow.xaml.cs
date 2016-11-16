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

namespace Knight_Documenter_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] filenames;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Main_Function
        private void Function_Test(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

        #region FileSelection
        private void File_Selection(object sender, RoutedEventArgs e)
        {
            //create open file dialog
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Multiselect = true;

            //Set filter to c++ and c# files and .txt files
            dialog.DefaultExt = ".txt";
            dialog.Filter = "TEXT FILES (*.txt)|*.txt|CPP FILES (*.cpp)|.cpp|CPP HEADERS (*.h)|*.h|C# FILES (*.cs)|*.cs|ALL FILES (*.*)|*.*";

            //Display open file dialog
            Nullable<bool> result = dialog.ShowDialog();

            //Get selected file names
            if(result == true)
            {
                //Open files
                filenames = dialog.FileNames;
                for (int i = 0; i < filenames.Length; i++)
                {
                    Selected_File.Text += filenames[i] + "\n";
                }
            }
        }

        private void ClearSelectedFiles(Object sender, RoutedEventArgs e)
        {
            //Clear files if there are actually files
            if (filenames != null && filenames.Length < 0)
            {
                Array.Clear(filenames, 0, filenames.Length);
            }

            //Set the text box back to normal
            Selected_File.Text = "";
            
        }
        #endregion
    }
}
