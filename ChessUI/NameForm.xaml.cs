using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
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
using ChessLogic;

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

            // If validation is enabled, call the validation functions
            if (isValidationEnabled)
            {
                bool whiteValid = CallWhiteValidation(WhitePlayerName.Text);
                bool blackValid = CallBlackValidation(BlackPlayerName.Text);
                bool isValid = ValidateForm(WhitePlayerName.Text, BlackPlayerName.Text);

                // If all validations pass, proceed to the next page
                if (isValid && whiteValid && blackValid)
                {
                    ReturnMessage.Visibility = Visibility.Hidden; // Hide the error label
                    NavigateToNextPage();
                }
                
            }
            else
            {
                // Proceed to next page without validation
                NavigateToNextPage();
            }
        }

        private bool ValidateForm(string whitePlayer, string blackPlayer)
        {
            if (string.IsNullOrWhiteSpace(whitePlayer) || string.IsNullOrWhiteSpace(blackPlayer))
            {
                ReturnMessage.Content = "Both player names must be filled."; // Error message for empty fields
                ReturnMessage.Visibility = Visibility.Visible;
                return false;
            }
            if (whitePlayer.Equals(blackPlayer, StringComparison.OrdinalIgnoreCase))
            {
                ReturnMessage.Content = "Players cannot have the same name."; // Error message for duplicate names
                ReturnMessage.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

        private bool CallWhiteValidation(string WPlayerName)
        {
            
            if (WPlayerName.Length < 2)
            {
                WhitePlayerName.BorderBrush = new SolidColorBrush(Colors.Red);
                ReturnMessage.Content = "White Player Name cannot be less that 2 characters";
                ReturnMessage.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                WhitePlayerName.BorderBrush = new SolidColorBrush(Colors.White); // Reset background color if valid
                return true;
            }
        }

        private bool CallBlackValidation(string BPlayerName)
        {
         
            if (BPlayerName.Length < 2)
            {
                BlackPlayerName.BorderBrush = new SolidColorBrush(Colors.Red);
                ReturnMessage.Content = "Black Player Name cannot be less that 2 characters";
                ReturnMessage.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                BlackPlayerName.BorderBrush = new SolidColorBrush(Colors.White); // Reset background color if valid
                return true;
            }
        }

        
        private void NavigateToNextPage()
        {
            string whitePlayerName = WhitePlayerName.Text;
            string blackPlayerName = BlackPlayerName.Text;

            // Pass the player names to MainWindow
            MainWindow mainWindow = new MainWindow(whitePlayerName, blackPlayerName);
            mainWindow.Show();
            this.Close();
        }
        
    }
}

