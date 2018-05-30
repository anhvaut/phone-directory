/**
 * Vu The Tran
 * 21/11/09
 */
//using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;


namespace CommonLibrary.OutlookContact
{
    public class ContactManagement
    {
        public static Dictionary<string,Model.Contact> RetreiveAllContact(bool accessEmal)
        {
            
            Application outLook = new Application();
            NameSpace outLookNS = outLook.GetNamespace("MAPI");
            MAPIFolder cf = outLookNS.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
            Items ctcItems = cf.Items;

            Dictionary<string, Model.Contact> contacts = new Dictionary<string, CommonLibrary.Model.Contact>();

            for (int j = 1; j < (ctcItems.Count + 1); j++)
            {
                ContactItem ctc = (ContactItem)ctcItems[j];

                Model.Contact contact=new CommonLibrary.Model.Contact();
                contact.FullName = ctc.FullName.ToString();

                contact.Address = ctc.HomeAddress == null? "" : ctc.HomeAddress.ToString();
                contact.HomePhone = ctc.HomeTelephoneNumber == null? "" : ctc.HomeTelephoneNumber.ToString();
                contact.MobilePhone = ctc.MobileTelephoneNumber == null? "" : ctc.MobileTelephoneNumber.ToString();

                if(accessEmal)
                contact.Email = ctc.Email1Address == null ? "" : ctc.Email1Address.ToString();

                contact.BusinessPhone = ctc.BusinessTelephoneNumber == null ? "" : ctc.BusinessTelephoneNumber.ToString();
                contact.BusinessFax = ctc.BusinessFaxNumber == null ? "" : ctc.BusinessFaxNumber.ToString();
                contact.IPPhone = "";

                if (!contacts.ContainsKey(contact.FullName))
                    contacts.Add(contact.FullName, contact);
            }

            return contacts;


        }

        public void AddNewContact(Model.Contact contact)
        {
               Application outlookApp = new Application();
               ContactItem newContact = (ContactItem)outlookApp.CreateItem(OlItemType.olContactItem);

                
                newContact.FullName = contact.FullName;
                newContact.Email1Address = contact.Email;
                newContact.HomeAddress = contact.Address;
                newContact.HomeTelephoneNumber = contact.HomePhone;
                newContact.MobileTelephoneNumber= contact.MobilePhone;
                newContact.BusinessTelephoneNumber =contact.BusinessPhone;
                newContact.BusinessFaxNumber = contact.BusinessFax;
                newContact.Save();
                //newContact.Display(true);
            
        }

        public void ComposeMessage(string email)
        {
            Application oApp = new Application();
            MailItem oMsg =(MailItem)oApp.CreateItem(OlItemType.olMailItem);
            Recipient oRecip;
            oRecip = (Recipient)oMsg.Recipients.Add(email);
            oRecip.Resolve();
            oMsg.Display(true);

            //oRecip = null;
            //oMsg = null;
            //oApp = null;
        }

    }
}
