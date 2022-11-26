namespace Domain
{
    public class Apartment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Floor { get; set; }
        public double Percentage { get; set; }
        public Building Building { get; set; }
        public ICollection<Receipt> Receipts { get; set; }

        
    }
}