using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UXUI.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUp : Page
    {
        public SignUp()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameInput.Text!=""&& PasswordInput.Password !="")
            {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "data source = DESKTOP-ILURVPI; initial catalog = Library; integrated security = True; ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            connection.Open();
            cmd.CommandText = "insert into loginTable (username,pass,Admin) values ('" + UsernameInput.Text + "','" +PasswordInput.Password+"','False')";
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageDialog dialog = new MessageDialog("Acc has been registered", "Success");
            dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Fill All The Fields", "Failed!");
                dialog.ShowAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginScreen));
        }
    }
}
