using Peticom.Core.Models.DataTable;

namespace Peticom.Core.Models;

public class AdFilterResponseModel : DataTableBaseResponseModel<AdModel>
{
    public AdFilterResponseModel(List<AdModel> data, int recordsTotal, int recordsFiltered) 
        : base(data, recordsTotal, recordsFiltered)
    {
        
    }
}