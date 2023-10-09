using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("Tbl_Project")]
    public class Project
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required, MaxLength(300)]
        public string? Title { get; set; }

        [Required, MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date), Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date), Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Technologies Used")]
        public string? TechnologiesUsed { get; set; }

        [Display(Name = "Projet URL")]
        public string? ProjectUrl { get; set; }

		[NotMapped]
        [Display(Name = "Image")]
		public IFormFile? ImageFile { get; set; }

        public string? ImageName { get; set; }

        [Required]
        public Category Category { get; set; }
       
    }

    public enum Category
    {
        [Display(Name = "Backend Development")]
        BackendDevelopment,
        Cloud,
        [Display(Name = "Data Analysis")]
        DataAnalysis,
        Database,
        [Display(Name = "Frontend Development")]
        FrontendDevelopment,
        [Display(Name = "Graphic Design")]
        GraphicDesign,
        [Display(Name = "Mobile Development")]
        MobileDevelopment,
        [Display(Name = "UI UX")]
        UiUx,
        [Display(Name = "Web Development")]
        WebDevelopment
    }

}
