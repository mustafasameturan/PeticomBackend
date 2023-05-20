namespace Peticom.Core.Models;

public class ErrorModel
{
    // the private uses reason is to prevent the user from changing the list
    public List<string> Errors { get; private set; } = new List<string>();

    public ErrorModel(string error)
    {
        Errors = new List<string>();
        Errors.Add(error);
    }

    public ErrorModel(List<string> errors)
    {
        Errors = errors;
    }
}