namespace Lomo_Template.Models
{
    public class Addresses
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Address { get; set; }

        private People people;
        public People GetPeople() { return people; }
        public void SetPeople(People value) { people = value; }
    }
}
