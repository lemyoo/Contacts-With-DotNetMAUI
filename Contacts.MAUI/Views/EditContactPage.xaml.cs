namespace Contacts.MAUI.Views;
using Contacts.MAUI.Models;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Models.Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
	
	public string ContactId
	{
		set
		{
			contact = ContactRepository.GetContact(int.Parse(value));
			if (contact != null)
			{
                contactControl.Name = contact.Name;
                contactControl.Email = contact.Email;
                contactControl.Phone = contact.Phone;
                contactControl.Address = contact.Address;

			}
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
			contact.Name = contactControl.Name; 
            contact.Email = contactControl.Email;
			contact.Phone = contactControl.Phone;
			contact.Address = contactControl.Address;

			ContactRepository.UpdateContacts(contact.ContactId, contact);

			Shell.Current.GoToAsync("..");
		
		
    }

    private void contactControl_OnError(object sender, string e)
    {
		DisplayAlert("Error", e, "Ok"); 
    }
}