using ClassLibrary1.Classes;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UXUI.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudentDashboard : Page
    {
        ItemsCollection itemsCollection;
        public StudentDashboard()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (itemsCollection == null && e.Parameter != null)
            {
                base.OnNavigatedTo(e);
                itemsCollection = (ItemsCollection)e.Parameter;
            }
        }
        

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewBooks),itemsCollection);
        }

        private void ReturnBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReturnLiterature), itemsCollection);
        }

        private void IssueBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(IssueBook), itemsCollection);
        }

        private async void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Exit?",
                Content = "Are You Sure",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No"
            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Application.Current.Exit();
            }
        }
    }
}
