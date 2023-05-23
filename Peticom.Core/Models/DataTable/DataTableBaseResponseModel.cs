namespace Peticom.Core.Models.DataTable;

public class DataTableBaseResponseModel<T> where T : class
{
    public DataTableBaseResponseModel(List<T> data, int recordsTotal, int recordsFiltered)
    {
        Data = data;
        RecordsTotal = recordsTotal;
        RecordsFiltered = recordsFiltered;
    }
    
    public int RecordsTotal { get; set; }
    public int RecordsFiltered { get; set; }
    public List<T> Data { get; set; }
}