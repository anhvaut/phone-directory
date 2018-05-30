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
        public static Dictionary<string,Model.Contact> RetreiveAllContact()
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

                if (!contacts.ContainsKey(contact.FullName))
                    contacts.Add(contact.FullName, contact);
            }

            return contacts;


        }

    }
}
