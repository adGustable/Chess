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
using System.Windows.Shapes;
using System.IO;

namespace ChessUI.FormUI
{
    /// <summary>
    /// Interaction logic for TestForm.xaml
    /// </summary>
    public partial class TestForm : Window
    {
        private const string Path2 = "C:\\Users\\faber\\OneDrive\\Documents\\GitHub\\Chess\\ChessUI\\FormUI\\WebContent\\";

        public TestForm()
        {
            InitializeComponent();

            // Get the path to the HTML file
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, Path2, "index.html");

            // Convert the path to a URL format
            webBrowser.Navigate(new Uri(path));
        }

        public void OnFormSubmitted(bool isValid)
        {
            if (isValid)
            {
                // Redirect to a WPF window
                var mainWindow = new MainWindow(); // Replace with your actual window
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Validation failed.");
            }
        }

    }
}
