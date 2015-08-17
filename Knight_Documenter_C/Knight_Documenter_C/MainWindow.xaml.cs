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

        public List<string> Results = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestCommentExtractor()
        {
            Results = reader.OperateOnFile("C:/Users/Brian's/Documents/GitHub/Knight_Documenter/Knight_Documenter_C/TestFile.txt", Method.eComments);
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

    }
}
