using Peticom.Core.Enums;
using Peticom.Core.Models.DataTable;

namespace Peticom.Core.Models;

public class AdFilterRequestModel : DataTableBaseRequestModel
{
    public int? CityId { get; set; }
    public int? Order { get; set; }
    public Pet? Type { get; set; }
}