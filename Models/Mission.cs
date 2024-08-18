using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
    public class Mission
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        [Required]
        public SiteChoice Site { get; set; }

        [Required]
        public EmployeeChoice Employee { get; set; }
    }
    public enum SiteChoice
    {
        SiteA,
        SiteB,
        SiteC,
        SiteD
    }
    public enum EmployeeChoice
    {
        Employe,
        Gardien,
        Conseiller,
        Directeur,
        Agent
    }
}
