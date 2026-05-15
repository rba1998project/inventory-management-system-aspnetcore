namespace IMS.WEB.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ContactPerson { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public int ProductCount { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}