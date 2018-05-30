using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.OutlookExpress
{
    public class ContactManagement
    {
        public static Dictionary<string, Model.Contact> RetreiveAllContact()
        {
            Dictionary<string, Model.Contact> contacts = new Dictionary<string, CommonLibrary.Model.Contact>();

            NKTWABLib.NKTWAB NKT = new NKTWABLib.NKTWAB();
            NKTWABLib.Folder rootFolder = NKT.RootFolder;

            NKTWABLib.ContactContainer contCont = (NKTWABLib.ContactContainer)NKT.get_Item(rootFolder.Folders.get_Item(1).EntryID);
            //ComctlLib.Node tvItem = new ComctlLib.Node();

            for (int i = 1; i <= contCont.Contacts.Count; i++)
            {
                Model.Contact contact = new CommonLibrary.Model.Contact();

                NKTWABLib.Contact item = contCont.Contacts.get_Item(i);
                contact.FullName = item.Name;

                contact.Address = item.HomeAddressCity;
                contact.HomePhone = item.HomeTelephoneNumber;
                contact.MobilePhone = item.MobileTelephoneNumber;
                contact.Email = item.Email1Address;

                contact.BusinessPhone = item.BusinessTelephoneNumber;
                contact.BusinessFax = item.BusinessFaxNumber; 
                contact.IPPhone = "";


                if (!contacts.ContainsKey(contact.FullName))
                    contacts.Add(contact.FullName, contact);
            }

            return contacts;
        }
    }
}
