using System.ComponentModel.DataAnnotations.Schema;

namespace Automation_System.Entities
{
    public class CustomerDefaultBillingAddress
    {
        
        public int Id { get; set; }
        [Column("zip")]
        public int Zip { get; set; }
        [Column("country")]
        public string Country { get; set;}
        [Column("address")]
        public string Address { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("street2")]
        public string Street2 { get; set; }
        [Column("state")]
        public string State { get; set; }
        [Column("fax")]
        public string Fax { get; set; }
        [Column("state_code")]
        public string StateCode { get; set; }
        public int ZohoDataId { get; set; }
    }
}
