using ClassLibrary1;
using ClassLibrary1.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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
    public sealed partial class ViewBooks : Page
    {
         ItemsCollection itemsCollection;
        

        public ViewBooks()
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
       
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
           
            if (itemsCollection.IsAdmin.ToString()== "True" )
            {
              Frame.Navigate(typeof(Dashboard));
            }
            else
            {
                Frame.Navigate(typeof(StudentDashboard));
            }
        }

        private void listview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var literature = e.ClickedItem;
            LiteratureInfo.Text = literature.ToString();
            LiteratureInfo.Foreground = new SolidColorBrush(Windows.UI.Colors.YellowGreen);
            
            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            

            if (NameSearch.IsChecked==true)
            {
                if (Input.Text != "")
                {
                 itemsCollection.SearchByName(Input.Text);
                 
                }
            }
            else if (AutherSearch.IsChecked==true)
            {
                if (Input.Text != "")
                {
                    itemsCollection.SearchByAuther(Input.Text);
                }
            }
            else if (PublisherSearch.IsChecked == true)
            {
                if (Input.Text != "")
                {
                    itemsCollection.SearchByPublisher(Input.Text);
                }
            }
            else if (GenreSearch.IsChecked == true)
            {
                if (Input.Text != "")
                {
                    itemsCollection.SearchByGenre(Input.Text);
                }
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Choose Category", "Error!");
                dialog.ShowAsync();
            }
            if (Searchedlistview.Items.Count > 0)
            {
              Searchedlistview.Items.Clear();
            }
            foreach (Library item in itemsCollection.ShowFilteredList())
            {
                Searchedlistview.Items.Add(item);
            }

            
        }
    }
}
