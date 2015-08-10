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
            //test to see if commenter works
            TestCommentExtractor();
            ResultListBox.ItemsSource = Results;
            //Double checking to make sure the operation finished
            MessageBox.Show("Operation Compleeted");
        }
    }
}
