using System;
using System.Collections.Generic;
using System.Text;

namespace BlinkTheLed.Models
{
    class Contact
    {
        public string Name { get; set; }
        public string Mac { get; set; }

        public Contact(string _name, string _mac)
        {
            Name = _name;
            Mac = _mac;
        }
    }
}
