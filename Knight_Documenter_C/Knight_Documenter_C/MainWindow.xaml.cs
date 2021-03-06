﻿using System;
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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Knight_Documenter_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //All of the user selected files
        private string[] filenames;
        private Window resultsWindow = new Window() { Height = 1000, Width = 1000};

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Documentation_Functions
        private void CommentExtraction()
        {
            //TODO:
            // -Set up Reader Class
            // -Set up TextDoc Class
            
        }

        private void ClassDiagram()
        {
            //TODO:
            // -Set up Drawing Class
            // -Set Up VisualDoc Class
        }

        private void FlowDiagram()
        {
            //TODO:
            // -Set up Drawing Class
            // -Set Up VisualDoc Class
        }
        #endregion

        #region Main_Function
        private void Function_Test(object sender, RoutedEventArgs e)
        {
            if (!resultsWindow.IsActive)
            {
                Drawing instance = new Drawing();
                Canvas testCanvas = new Canvas();

                TextandShape test = instance.CreateRectangleWithText(testCanvas, "This is some test text", 100, 100);

                resultsWindow.Content = testCanvas;
                resultsWindow.Show();
            }
            else
            {
                resultsWindow.Hide();
            }
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

        #region SetUpFunctions_ResultWindow

        #endregion SetUpFunctions_ResultWindow
    }
}
