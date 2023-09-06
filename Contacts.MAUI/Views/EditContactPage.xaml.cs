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
				entryName.Text = contact.Name;
				entryEmail.Text = contact.Email;
				entryPhone.Text = contact.Phone;
				entryAddress.Text = contact.Address;

			}
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
		contact.Name = entryName.Text;
		contact.Email = entryEmail.Text;
		contact.Phone = entryPhone.Text;
		contact.Address = entryAddress.Text;

		ContactRepository.UpdateContacts(contact.ContactId, contact);

		Shell.Current.GoToAsync("..");
    }
}