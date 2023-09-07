using Contacts.MAUI.Models;

namespace Contacts.MAUI.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactControlAdd_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }

    private void contactControlAdd_OnSave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            Name = contactControlAdd.Name, 
            Email = contactControlAdd.Email,
            Phone = contactControlAdd.Phone,
            Address = contactControlAdd.Address,
        });

        Shell.Current.GoToAsync("..");
    }
}