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
        LoadContacts();

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

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;

        ContactRepository.DeletContact(contact.ContactId);
        LoadContacts();
    }

    private void LoadContacts()
    {
        listContacts.ItemsSource = new ObservableCollection<Models.Contact>(ContactRepository.GetAll());

    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {

    }
}