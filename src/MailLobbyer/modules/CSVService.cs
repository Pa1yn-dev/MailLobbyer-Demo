using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using MailLobbyer.ContactClass;
using MailLobbyer.CSVFileClass;

namespace MailLobbyer.CSVServiceComponent
{
    public class CSVService
    {
        public List<Contact> contacts = new List<Contact>();

        public async Task CSVParser(IBrowserFile csvfile)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await csvfile.OpenReadStream().CopyToAsync(ms);
                    ms.Position = 0;

                    using (StreamReader reader = new StreamReader(ms))
                    {
                        string currentline;

                        reader.ReadLine();

                        while ((currentline = reader.ReadLine()) != null)
                        {
                            string[] substrings = currentline.Split(',');

                            Contact newcontact = new Contact(substrings[0], substrings[1], substrings[2], substrings[3]);
                            contacts.Add(newcontact);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
