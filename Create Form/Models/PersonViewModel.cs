using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 3)]
        public byte Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
