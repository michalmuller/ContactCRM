using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentiSoft.Models
{
    public class ContactVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }

        public List<ContactVM> contacts { get; set; }
    }
}