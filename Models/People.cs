namespace Lomo_Template.Models
{
    public class People
    {
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        private Addresses Addresses;

        public virtual Addresses GetAddresses()
        {
            return Addresses;
        }
        public virtual void SetAddresses(Addresses value)
        {
            Addresses = value;
        }
    }
}
