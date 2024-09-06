using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for NameForm.xaml
    /// </summary>
    public partial class NameForm : Window
    {
        public NameForm()
        {
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            bool isValidationEnabled = EnableValidation.IsChecked ?? false;

            // If validation is enabled, call the TypeScript validation logic
            if (isValidationEnabled)
            {
                CallValidation(WhitePlayerName.ToString(), BlackPlayerName.ToString());
            }
            else
            {
                // Proceed to next page without validation
                NavigateToNextPage();
            }
        }

        private void CallValidation(string WPlayerName, string BPlayerName)
        {

        }

        private void NavigateToNextPage()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        
    }
}

