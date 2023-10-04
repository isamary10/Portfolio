using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        //public string? ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date), Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Technologies Used")]
        public string? TechnologiesUsed { get; set; }
        [Display(Name = "Projet URL")]
        public string? ProjectUrl { get; set; }
        public IFormFile ImageFile { get; set; }
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
