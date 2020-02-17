using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Tech_System.BLL
{
    public class Customer
    {
        private int customerId;
        private string name;
        private int streetNo;
        private string streetName;
        private string postalCode;
        private string city;
        private string phoneNumber;
        private string faxNumber;
        private float credit;
        


        public int CustomerId { get => customerId; set => customerId = value; }
        public string Name { get => name; set => name = value; }
        public int StreetNo { get => streetNo; set => streetNo = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string City { get => city; set => city = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public float Credit { get => credit; set => credit = value; }
    }
}
