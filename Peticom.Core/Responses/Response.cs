using System.Text.Json.Serialization;
using Peticom.Core.Models;

namespace Peticom.Core.Responses;

public class Response<T>
{
    public T Data { get; private set; }
    public int StatusCode { get; set; }
    public string Message{ get; set; }
    
    [JsonIgnore] 
    public bool IsSuccessfull { get; private set; }
    
    public ErrorModel Error { get; private set; }
    
    
    public static Response<T> Success(T data, int statusCode)
    {
        return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessfull = true};
    }
    
    public static Response<T> Success(int statusCode)
    {
        return new Response<T> { Data = default, StatusCode = statusCode, IsSuccessfull = true};
    }

    public static Response<T> Success(string message, int statusCode)
    {
        return new Response<T> { Data = default, Message = message, StatusCode = statusCode, IsSuccessfull = true };
    }

    public static Response<T> Fail(ErrorModel errorModel, int statusCode)
    {
        return new Response<T> { Error = errorModel, StatusCode = statusCode, IsSuccessfull = false};
    }
    
    public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
    {
        var errorModel = new ErrorModel(errorMessage);
        
        return new Response<T> { Error = errorModel, StatusCode = statusCode, IsSuccessfull = false};
    }
}