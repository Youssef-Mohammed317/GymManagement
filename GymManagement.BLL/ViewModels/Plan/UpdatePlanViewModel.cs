using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.ViewModels.Plan
{
    public class UpdatePlanViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        [Range(1, 365, ErrorMessage = "Plan Must Be 1 to 365 days")]
        public int DurationInDays { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
