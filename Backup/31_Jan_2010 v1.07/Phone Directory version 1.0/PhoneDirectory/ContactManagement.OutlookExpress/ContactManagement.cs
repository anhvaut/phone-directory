/**************************************************************************\
* Telephone Directory v1.00                                                *
* http://www.wollundra.com.au  ,http://www.wollundra.com                   *
* Copyright (C) 2009-2010 by Wollundra Pty Ltd                             *
* Development Team : Tran The Vu                                           *
*                    John Fergus                                           *
*                    Shawns Richards                                       *
* ------------------------------------------------------------------------ *
*  The copyright of the Source code and its documentation is owned by      * 
* WOLLUNDRA Pty Ltd A.C.N 075 477 048. The unauthorised reproduction       *
* or distribution of this source code will result in criminal penalties.   *                                                     *
\**************************************************************************/

using System.Collections.Generic;
using Wollundra.ContactManagement.Model;


namespace Wollundra.ContactManagement.OutlookExpress
{
    public class ContactManagement
    {
        public static Dictionary<string, Model.Contact> RetreiveAllContact()
        {
            Dictionary<string, Model.Contact> contacts = new Dictionary<string, Model.Contact>();

            NKTWABLib.NKTWAB NKT = new NKTWABLib.NKTWAB();
            NKTWABLib.Folder rootFolder = NKT.RootFolder;

            NKTWABLib.ContactContainer contCont = (NKTWABLib.ContactContainer)NKT.get_Item(rootFolder.Folders.get_Item(1).EntryID);
            //ComctlLib.Node tvItem = new ComctlLib.Node();

            for (int i = 1; i <= contCont.Contacts.Count; i++)
            {
                Model.Contact contact = new Model.Contact();

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
