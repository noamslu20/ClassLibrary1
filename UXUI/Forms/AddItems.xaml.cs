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
using ClassLibrary1.Classes;
using ClassLibrary1;
using UXUI;
using UXUI.Forms;
using System.Data.SqlClient;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UXUI.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public  partial class AddItems : Page 
    {
        ItemsCollection instance;
        List<Library> item = new List<Library>();

        public AddItems()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            instance = (ItemsCollection)e.Parameter;
            RefreshComboBoxes();
        }
        public void RefreshComboBoxes()
        {
            DeleteItems.Items.Clear();
            foreach (Library item in instance.ShowList())
            {
                DeleteItems.Items.Add(item.ToString());
            }
            EditItem.Items.Clear();
            foreach (Library item in instance.ShowList())
            {
                EditItem.Items.Add(item.ToString());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Adddatetime = AddDateTime.SelectedDate.ToString();
            if (BookSelect.IsChecked==true && AuthorAdd.Text!="" && PublisherAdd.Text != "" && AddDateTime.SelectedDate!=null && GenreAdd.SelectedItem!=null && AddRentPrice.Text!="" && AddSalePrice.Text!="")
            {
                item.Add(new Book(new Guid(), NameInput.Text, AuthorAdd.Text, PublisherAdd.Text, Convert.ToDateTime(Adddatetime), Enum.Parse<Genres>(GenreAdd.SelectedItem.ToString()), double.Parse(AddRentPrice.Text), double.Parse(AddSalePrice.Text), Convert.ToDateTime(Adddatetime)));
                instance.AddItem(item.First());
                DeleteItems.Items.Add(instance.ShowItem(item.First()));
                EditItem.Items.Add(instance.ShowItem(item.First()));
                item.Clear();
                MessageDialog dialog = new MessageDialog("New book has been added","Success");
                dialog.ShowAsync();

                
            }
            else if (JournalSelect.IsChecked ==true && NameInput.Text!="" && AuthorAdd.Text != "" && PublisherAdd.Text != "" && AddDateTime != null && GenreAdd.SelectedItem != null && AddRentPrice.Text != "" && AddSalePrice.Text != "" && AddRentDateTime != null)
            {
                item.Add(new Journal(new Guid(),NameInput.Text ,AuthorAdd.Text, PublisherAdd.Text, Convert.ToDateTime(Adddatetime), Enum.Parse<Genres>(GenreAdd.SelectedItem.ToString()), double.Parse(AddRentPrice.Text), double.Parse(AddSalePrice.Text), Convert.ToDateTime(Adddatetime)));
                instance.AddItem(item.First());
                DeleteItems.Items.Add(instance.ShowItem(item.First()));
                EditItem.Items.Add(instance.ShowItem(item.First()));
                item.Clear();
                MessageDialog dialog = new MessageDialog("New Journal has been added", "Success");
                dialog.ShowAsync();

            }
            else
            {
                
                MessageDialog dialog = new MessageDialog("Wrong Input!");
                dialog.ShowAsync();
            }
            
        }   

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Dashboard),instance);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteItems.SelectedIndex != -1)
            {
            int id = DeleteItems.SelectedIndex;
            DeleteItems.Items.RemoveAt(id);
            EditItem.Items.RemoveAt(id);
            
            instance.RemoveItem(id);
            MessageDialog dialog = new MessageDialog("Item has been deleted", "Success!");
            dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Nothing To Delete","Error!");
                dialog.ShowAsync();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            if (NameEdit.Text != "" && AuthorEdit.Text != "" && PublisherEdit.Text != "" && GenreEdit.Text !=null && EditRentDateTime.SelectedDate != null && EditDateTime.SelectedDate != null && EditRentPrice.Text != "" && EditSalePrice.Text != "")
            {
                string Editdatetime = EditDateTime.SelectedDate.ToString();
                string Editrentdatetime = EditRentDateTime.SelectedDate.ToString();
                int index = EditItem.SelectedIndex;
                instance.EditItem(index, AuthorEdit.Text, PublisherEdit.Text, Enum.Parse<Genres>(GenreEdit.SelectedItem.ToString()), NameEdit.Text, double.Parse(EditRentPrice.Text), double.Parse(EditSalePrice.Text), Convert.ToDateTime(Editdatetime), Convert.ToDateTime(Editrentdatetime));
                EditItem.Items.RemoveAt(index);
                EditItem.Items.Add(instance.ShowItem(instance.GetListFromIndex(index)));
                MessageDialog dialog = new MessageDialog("Item has been changed!", "Success!");
                dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Fill all the fields", "Error!");
                dialog.ShowAsync();
            }
            
            
        }
    }
}
