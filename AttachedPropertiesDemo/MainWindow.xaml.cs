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

namespace AttachedPropertiesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Text = string.Empty;
            txtName.SetValue(TextBoxExtension.WasUsedProperty, true); // Can this be made neater with the custom setter?
            TextBoxExtension.SetWasUsed(txtName, true); // Yes, it can!
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtName.Text) && (bool)txtName.GetValue(TextBoxExtension.WasUsedProperty)) // Can't we use the custom getter?
            {
                txtMessage.Text = $"Your name is {txtName.Text}!";
                txtMessage.Text += $" {TextBoxExtension.GetWasUsed(txtName)}"; // The hell it can!
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) btn_Click(sender, e);
        }
    }
}
