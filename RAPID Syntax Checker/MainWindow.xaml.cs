using Microsoft.Win32;
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


namespace RAPID_Syntax_Checker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region [Constructor]
        public MainWindow()
        {
            InitializeComponent();

        }
        #endregion

        #region [Event Handlers]
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            Open_File();

        }
        #endregion

        #region [Commands]
        private static void Open_File()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open RGcode File";
            openFileDialog.Filter = "MOD Files (*.mod)| *.mod";
            
            // Open window and check if file is valid
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show("It worked");
            }

        }
        #endregion


    }
}
