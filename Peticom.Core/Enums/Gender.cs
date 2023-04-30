using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum Gender
{
    [Display(Name = "Erkek")]
    Male = 0,
    [Display(Name = "Kadın")]
    Female,
    [Display(Name = "Belirtilmedi")]
    Unknown
}