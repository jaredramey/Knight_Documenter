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
        //Initialize Reader class
        Reader reader = new Reader();
        Draw draw = new Draw();

        public List<string> Results = new List<string>();

        string[] fileNames;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestCommentExtractor()
        {
            if (Selected_File.Text != "")
            {
                Results = reader.OperateOnFile(fileNames, Method.eComments);
            }
            else
            {
                MessageBox.Show("ERROR: No File(s) Selected!");
            }
        }

        private void ClassExtraction()
        {
            if(Selected_File.Text != "")
            {
                Results = reader.OperateOnFile(fileNames, Method.eClasses);
            }

            else 
            {
                MessageBox.Show("ERROR: No File(s) Selected!");
            }
        }

        private void ClassFuncExtraction_Test()
        {
            if (Selected_File.Text != "")
            {
                MessageBox.Show("Class Function Extraction Not Working Yet...");

                //Will update this once I have a working function
            //    Dictionary<string, string> tempDictionary = reader.GetClassFuncs(fileNames);
            //    for (int i = 0; i < tempDictionary.Count; i++ )
            //    {

            //    }
            }

            else
            {
                MessageBox.Show("ERROR: No File(s) Selected!");
            }
        }

        private void FunctionExtraction()
        {
            if (Selected_File.Text != "")
            {
                Results = reader.OperateOnFile(fileNames, Method.eFunc);
            }

            else
            {
                MessageBox.Show("ERROR: No File(s) Selected!");
            }
        }

        private void CommentExtraction_Test_Click(object sender, RoutedEventArgs e)
        {
            //Getting the string set for later use
            string selectedFunction = "";
            //Check combobox selection and go off the function selected by the user
            ComboBoxItem function = (ComboBoxItem)FunctionSelection.SelectedItem;
            //Make sure the default selection on the combobox isn't selected
            if (function.Content.ToString() != "Select A Function")
            { 
                selectedFunction = function.Content.ToString();
            }
            else
            {
                selectedFunction = "No function Selected";
            }

            //Switch on selectedFuntion to do requested function
            switch(selectedFunction)
            {
                    //If commentExtraction is selected
                case "Comment Extraction":
                    //test to see if commenter works
                    TestCommentExtractor();
                    ResultListBox.ItemsSource = Results;
                    //Double checking to make sure the operation finished
                    MessageBox.Show("Operation Compleeted");
                    break;

                case "Class Extraction":
                    //Call function to operate via class extraction
                    ClassExtraction();
                    ResultListBox.ItemsSource = Results;
                    //Let the user know that the operation has compleeted
                    MessageBox.Show("Operation Compleeted");
                    break;

                case "Function Extraction":
                    FunctionExtraction();
                    ResultListBox.ItemsSource = Results;
                    MessageBox.Show("Operation Compleeted");
                    break;

                    //Test case to test other functions occuring
                case "Function 2":
                    //Just telling myself another function was selected
                    MessageBox.Show(selectedFunction);
                    break;

                    //If no function was selected then default to telling the user nothing was selected
                default:
                    MessageBox.Show("No Function Selected");
                    break;
            }
            
        }

        private void File_Select_Click(object sender, RoutedEventArgs e)
        {
            //Create open file dialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;

            //Set filter to c++ and c# header files and regular files (.txt as well for testing purposes)
            dlg.DefaultExt = ".txt";
            dlg.Filter = "TEXT FILES (*.txt)|*.txt|CPP FILES (*.cpp)|*.cpp|CPP HEADERS (*.h)|*.h|C# FILES (*.cs)|*.cs|All Files (*.*)|*.*";

            //Display open file dialog by calling show dialog method
            Nullable<bool> result = dlg.ShowDialog();

            //Get selected file name, put it into a textbox
            if(result == true)
            {
                //open document(s)
                fileNames = dlg.FileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    Selected_File.Text += fileNames[i] + "\n";
                }
            }
        }

    }
}
