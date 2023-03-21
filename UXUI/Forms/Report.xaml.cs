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
    public sealed partial class Report : Page
    {
        ItemsCollection itemsCollection;
        public Report()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (itemsCollection == null && e.Parameter != null)
                itemsCollection = (ItemsCollection)e.Parameter;
            itemsCollection.CountLiterature(0,0);
            TotalBooks.Text = itemsCollection.GetCountBook.ToString();
            TotalJournals.Text = itemsCollection.GetCountJournals.ToString();
            TotalItems.Text = itemsCollection.GetTotalItems.ToString();
            TotalBorrowd.Text = itemsCollection.GetCountOfBorrowd.ToString();
            InStock.Text = itemsCollection.GetItemsInStock.ToString();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (itemsCollection.IsAdmin.ToString() == "True")
            {
                Frame.Navigate(typeof(Dashboard));
            }
            else
            {
                Frame.Navigate(typeof(StudentDashboard));
            }
        }
    }
}
