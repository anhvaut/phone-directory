using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DirectoryInfo di = new DirectoryInfo("C:/abc/def");
            //di.Create();

            NKTWABLib.NKTWAB NKT = new NKTWABLib.NKTWAB();
            NKTWABLib.Folder rootFolder = NKT.RootFolder;

            listBox1.Items.Add(rootFolder.Folders.Count);

            ////NKTWABLib.Contacts item = new NKTWABLib.Contacts();

            ////ComctlLib.ListItem lvItem = new ComctlLib.ListItem();
            //NKTWABLib.ContactContainer contCont = (NKTWABLib.ContactContainer)NKT.get_Item(rootFolder.Folders.get_Item(1).EntryID);
            ////ComctlLib.Node tvItem = new ComctlLib.Node();

            //for (int i = 1; i <= contCont.Contacts.Count;i++ )
            //{
            //    NKTWABLib.Contact item = contCont.Contacts.get_Item(i);
            //    listBox1.Items.Add(item.Name);
            //}

            //MessageBox.Show("" + contCont.Contacts.Count);


           // System.Diagnostics.Process.Start("mailto:email@add ress?subject=mysubject");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //NKTWABLib.NKTWAB NKT = new NKTWABLib.NKTWAB();
            //NKTWABLib.Folder rootFolder = NKT.RootFolder;

            //listBox1.Items.Add(rootFolder.Folders.get_Item(1));
            //MessageBox.Show(rootFolder.Folders.get_Item(1).EntryID);
            //MessageBox.Show(rootFolder.Folders.get_Item(1).Name);
        }


        //public string GetEntryID(ref string key)
        //{
        //    short endPos; 
    		
        //    endPos = key.IndexOf("&");
        //    if (endPos == -1)
        //        endPos = key.Length;

    		
        //    endPos = endPos - 1;
    		
        //    GetEntryID = Mid(key, 2, endPos);
        //}

    }
}
