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


namespace RAPID_Syntax_Checker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region [Variables]
        public static string modulename;
        #endregion

        #region [Constructor]
   
        // Initializes Main Window
        public MainWindow()
        {
            InitializeComponent();

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
            Set_Module_Editor_Text(modulename);

        }
        #endregion

        #region [Commands]
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

        }

        public void Set_Module_Editor_Text(string my_modulename)
        {
           
            ModuleViewer.Text = File.ReadAllText(my_modulename);
            
        }
        #endregion


    }
}


