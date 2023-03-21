using ClassLibrary1;
using ClassLibrary1.Classes;
using System;
using System.Collections.Generic;
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
    public sealed partial class ReturnLiterature : Page
    {
        ItemsCollection itemsCollection;
        public ReturnLiterature()
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
            BorrrowdSelect.Items.Clear();
            foreach (Library item in itemsCollection.ShowBorrowdList())
            {
                BorrrowdSelect.Items.Add(item.ToString());
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

        private void ReturnLiteratureBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BorrrowdSelect.SelectedIndex >= 0)
            {
                if (itemsCollection.isLate(BorrrowdSelect.SelectedIndex))
                {
                    var Latemessage = new MessageDialog("Item has been returned in late!", "Later WARNING");
                    Latemessage.ShowAsync();
                }
                itemsCollection.ReturnFromBorrowd(BorrrowdSelect.SelectedIndex);
                var messageDialog = new MessageDialog("Item has been returned", "Success");
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
