namespace Peticom.Core.Models.DataTable;

public class DataTableBaseRequestModel
{
    public int Start { get; set; }
    public int Limit { get; set; }
    public string Search { get; set; }
}