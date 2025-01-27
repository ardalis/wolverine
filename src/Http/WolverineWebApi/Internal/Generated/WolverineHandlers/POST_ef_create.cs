// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_ef_create
    public class POST_ef_create : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _options;
        private readonly Microsoft.EntityFrameworkCore.DbContextOptions<WolverineWebApi.ItemsDbContext> _dbContextOptions;

        public POST_ef_create(Wolverine.Http.WolverineHttpOptions options, Microsoft.EntityFrameworkCore.DbContextOptions<WolverineWebApi.ItemsDbContext> dbContextOptions) : base(options)
        {
            _options = options;
            _dbContextOptions = dbContextOptions;
        }



        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var efCoreEndpoints = new WolverineWebApi.EfCoreEndpoints();
            await using var itemsDbContext = new WolverineWebApi.ItemsDbContext(_dbContextOptions);
            var (command, jsonContinue) = await ReadJsonAsync<WolverineWebApi.CreateItemCommand>(httpContext);
            if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
            efCoreEndpoints.CreateItem(command, itemsDbContext);
            // Wolverine automatically sets the status code to 204 for empty responses
            httpContext.Response.StatusCode = 204;
            
            // Added by EF Core Transaction Middleware
            var result_of_SaveChangesAsync = await itemsDbContext.SaveChangesAsync(httpContext.RequestAborted).ConfigureAwait(false);

        }

    }

    // END: POST_ef_create
    
    
}

