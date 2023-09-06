using Contacts.MAUI.Models;
using System.Collections.ObjectModel;

namespace Contacts.MAUI.Views;


public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
    }
   protected override void OnAppearing()
    {
        base.OnAppearing();

        listContacts.ItemsSource =new ObservableCollection<Models.Contact> (ContactRepository.GetAll());
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Models.Contact) listContacts.SelectedItem).ContactId}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
     }
}