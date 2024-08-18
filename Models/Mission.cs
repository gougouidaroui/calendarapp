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
    }
}
