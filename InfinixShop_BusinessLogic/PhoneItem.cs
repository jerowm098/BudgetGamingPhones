using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InfinixShop_Common
{
    public class PhoneItem
    {
        public int Id { get; set; } // store the unique ID of the phone item.
        public string Name { get; set; }    // store the name of the phone item.

        public PhoneItem() { }

        public PhoneItem(int id, string name) // initializes a new instance of PhoneItem
        {
            Id = id;    // Initialize the Id property with the provided id value.
            Name = name;    // Initialize the Name property with the provided name value.
        }
    }
}
