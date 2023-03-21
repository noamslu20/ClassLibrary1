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
using ClassLibrary1;
using ClassLibrary1.Classes;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UXUI.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IssueBook : Page
    {
        ItemsCollection itemsCollection;
        public IssueBook()
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
            RefreshList();
        }

        public void RefreshList()
        {
            Litrature.Items.Clear();
            foreach (Library item in itemsCollection.ShowList())
            {
                Litrature.Items.Add(item.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void IssueLiteratureBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Litrature.SelectedIndex >=0)
            {
                itemsCollection.AddToBorrowd(Litrature.SelectedIndex);
                var messageDialog = new MessageDialog("Item has been issued", "Success");
                messageDialog.ShowAsync();
                RefreshList();
            }
            else
            {
                var messageDialog = new MessageDialog("No Items", "Error");
                messageDialog.ShowAsync();
            }
            
        }
    }
}
