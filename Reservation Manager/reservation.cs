using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation_Manager
{
    internal class reservation
    {
        public reservation() { }
        public reservation(string partyName, string email, string phone, string size, string date, string time, string requests)
        {
            this.partyName = partyName;
            this.email = email;
            this.phone = phone;
            this.size = size;
            this.date = date;
            this.time = time;
            this.requests = requests;
        }
        public string partyName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string size { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string requests { get; set; }

        public string toString ()
        {
            string toReturn = "Party Name: " + partyName + " \nEmail: " + email + " \nDate: " + date + " \nTime: " + time;
            return toReturn;
        }
    }
}
