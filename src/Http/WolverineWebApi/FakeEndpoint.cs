using Microsoft.AspNetCore.Mvc;
using Wolverine.Http;

namespace WolverineWebApi;

public class FakeEndpoint
{
    [WolverineGet("/hello", Order = 55, Name = "The Hello Route!")]
    public string SayHello()
    {
        return "Hello";
    }
    
    [WolverineGet("/hello/async")]
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello");
    }
    
    [WolverineGet("/hello/async2")]
    public ValueTask<string> SayHelloAsync2()
    {
        return ValueTask.FromResult("Hello");
    }
    
    [WolverinePost("/go")]
    public void Go()
    {
        
    }
    
    [WolverinePost("/go/async")]
    public Task GoAsync()
    {
        return Task.CompletedTask;
    }
    
    [WolverinePost("/go/async2")]
    public ValueTask GoAsync2()
    {
        return ValueTask.CompletedTask;
    }

    [WolverineGet("/response")]
    public BigResponse GetResponse()
    {
        return new BigResponse();
    }
    
    [WolverineGet("/response2")]
    public Task<BigResponse> GetResponseAsync()
    {
        return Task.FromResult(new BigResponse());
    }
    
        
    [WolverineGet("/response3")]
    public ValueTask<BigResponse> GetResponseAsync2()
    {
        return ValueTask.FromResult(new BigResponse());
    }

    [WolverineGet("/read/{name}")]
    public string ReadStringArgument(string name)
    {
        return $"name is {name}";
    }
}

public class BigResponse
{
}