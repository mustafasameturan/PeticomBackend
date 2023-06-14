using System.ComponentModel.DataAnnotations;

namespace Peticom.Core.Enums;

public enum Pet
{
    [Display(Name = "Kedi")]
    Cat = 0,
    [Display(Name = "Köpek")]
    Dog
}