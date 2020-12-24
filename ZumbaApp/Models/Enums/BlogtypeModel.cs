using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZumbaApp.Models.Enums
{
    public enum BlogtypeModel
    {
        [Display(Name = "Technology")]
        Technology,
        [Display(Name = "Lifestyle")]
        LifeStyle,
        [Display(Name = "Marketing")]
        Marketing,
        [Display(Name = "Health & Fitnesss")]
        HealthFitness,
        [Display(Name = "Music")]
        Music,
        [Display(Name = "Productivity")]
        Productivity
    }
}