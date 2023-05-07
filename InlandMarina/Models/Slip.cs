namespace InlandMarina.Models
{
    public class Slip
    {
        // EF will instruct the database to automatically generate value for the Slip ID
        public int ID { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int DockID { get; set; }

        // navigation properties
        public virtual Dock? Dock { get; set; }
        public virtual ICollection<Lease>? Leases { get; set; }
    }
}
