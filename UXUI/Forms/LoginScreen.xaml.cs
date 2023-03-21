using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using UXUI.Forms;
using ClassLibrary1.Classes;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UXUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginScreen : Page
    {
        ItemsCollection instance;

        public LoginScreen()
        {
            this.InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UserNameInput.Text = "";
            PasswordInput.Password="";
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "data source=DESKTOP-M586SK6;initial catalog=Library;integrated security=True;";
            connection.Open();
            connection.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from loginTable where username = '"+UserNameInput.Text+"' and pass ='"+PasswordInput.Password+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count!=0)
            {
                object value = ds.Tables[0].Rows[0]["Admin"];
                if (value.ToString() == "True")
                {
                    if (instance == null)
                        instance = new ItemsCollection((bool)value);
                        Frame.Navigate(typeof(Dashboard), instance);
                }
                else
                {
                    if (instance == null)
                        instance = new ItemsCollection((bool)value);
                    Frame.Navigate(typeof(StudentDashboard), instance);
                }
            }
            else
            {
                var messageDialog = new MessageDialog("Wrong Username Or Password","Error");
                await messageDialog.ShowAsync();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }
    }
}
