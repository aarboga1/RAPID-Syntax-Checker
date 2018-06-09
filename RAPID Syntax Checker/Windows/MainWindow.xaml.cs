using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using RAPID_Syntax_Checker.Tools;


namespace RAPID_Syntax_Checker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region [Variables]
        public static string modulename;
        private string project_directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        #endregion

        #region [Constructor]

        // Initializes Main Window
        public MainWindow()
        {
            InitializeComponent();
            Set_Font_Size();

        }
        #endregion

        #region [Event Handlers]
        // Click Event For Exiting Window
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Click Event for Opening Module File
        private void Open_Click(object sender, EventArgs e)
        {
            Open_File();

            // Set module text editor to contents of meta data file
            Set_Module_Editor_Text(project_directory + @"\MetaData\MetaFile.txt");

        }

        private void Check_Syntax_Click(object sender, EventArgs e)
        {
            // Call Check Syntax Function
        }

        private void tencheck(object sender, RoutedEventArgs e)
        {
            twelvept.IsChecked = false;
            fourteenpt.IsChecked = false;

            Set_Font_Size();
        }

        private void twelvecheck(object sender, RoutedEventArgs e)
        {
            tenpt.IsChecked = false;
            fourteenpt.IsChecked = false;

            Set_Font_Size();
        }

        private void fourteencheck(object sender, RoutedEventArgs e)
        {
            twelvept.IsChecked = false;
            tenpt.IsChecked = false;

            Set_Font_Size();
        }
        #endregion

        #region [Commands]
        // Opens File Dialog 
        private static void Open_File()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open RGcode File",
                Filter = "MOD Files (*.mod)| *.mod"
            };

            // Open window and check if file is valid
            if (openFileDialog.ShowDialog() == true)
            {
                modulename = openFileDialog.FileName;
            }

            SyntaxChecker syntax = new SyntaxChecker(modulename);
            syntax.write_metadata();


        }

        // Sets text editor text
        public void Set_Module_Editor_Text(string my_modulename)
        {
           
            ModuleViewer.Text = File.ReadAllText(my_modulename);
            
        }

        // Sets the font size of the editor
        public void Set_Font_Size()
        {
            if (tenpt.IsChecked == true)
            {
                ModuleViewer.FontSize = 10;
            }
            else if (twelvept.IsChecked == true)
            {
                ModuleViewer.FontSize = 12;
            }
            else if (fourteenpt.IsChecked == true)
            {
                ModuleViewer.FontSize = 14;
            }
        }
        #endregion


    }
}


