using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheStableFriends747.Models
{
    public class Horse
    {
        public Guid Id { get; set; }
        public string HorseName { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageSource { get; set; }

      
    }
}
