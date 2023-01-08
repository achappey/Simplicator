using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.Mvc.Controllers;

using Simplicate.NET.Models.Http;
using Simplicate.NET;
using Simplicator.Services;
using Simplicator.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

var odataEndpoint = "odata";
var version = "v2";

var builder = WebApplication.CreateBuilder(args);
var appConfig = builder.Configuration.Get<AppConfig>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(version, new OpenApiInfo { Title = "Simplicator", Version = version });
    c.EnableAnnotations();

    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        return apiDesc.RelativePath != null ? docName == odataEndpoint ?
            apiDesc.RelativePath.Contains(odataEndpoint) : !apiDesc.RelativePath.Contains(odataEndpoint) : false;
    });

    c.AddSecurityDefinition("API Key", new OpenApiSecurityScheme
    {
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "API Key"
              },
              Name = "API Key",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });

    c.OperationFilter<ODataOperationFilter>();
});

builder.Services.AddHttpClient<SimplicateClient>(client => {
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("Conent-Type", "application/json");
});

builder.Services.AddScoped<SimplicateService>();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
}).AddOData(opt => opt.AddRouteComponents(odataEndpoint, GetGraphModel("Simplicator"))
            .Filter().Select().Expand().OrderBy().Count().SetMaxTop(999).SkipToken());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;

});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(
        string.Format("/swagger/{0}/swagger.json", version),
        "Simplicator");
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static IEdmModel GetGraphModel(string name)
{
    ODataConventionModelBuilder builder = new();

    builder.EntitySet<Simplicate.NET.Models.Employee>("Employees").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Organization>("Organizations").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.MyOrganization>("MyOrganizations").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Person>("Persons").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Hours>("Hours").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Project>("Projects").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.ProjectServices>("ProjectServices").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.SalesService>("SalesServices").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.DefaultService>("DefaultServices").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Sales>("Sales").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Quote>("Quotes").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.QuoteStatus>("QuoteStatuses").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.ProjectStatus>("ProjectStatuses").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.InvoiceStatus>("InvoiceStatuses").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.RevenueGroup>("RevenueGroups").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.SalesStatus>("SalesStatuses").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Industry>("Industries").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.SalesProgress>("SalesProgresses").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.SalesSource>("SalesSources").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.MessageType>("MessageTypes").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.QuoteTemplate>("QuoteTemplates").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Contract>("Contracts").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Invoice>("Invoices").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Message>("Messages").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Document>("Documents").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.DocumentType>("DocumentTypes").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.VatClass>("VatClasses").EntityType.Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.Avatar>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.MyOrganizationLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.NameLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.Address>().Namespace = name;    
    builder.ComplexType<Simplicate.NET.Models.LinkedProject>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.DocumentTypeLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.TypeLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.Address>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.LabelTypeLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.CustomField>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.QuoteStatusLookup>().Namespace = name;    
    builder.ComplexType<Simplicate.NET.Models.QuoteTemplateLookup>().Namespace = name;    
    builder.ComplexType<Simplicate.NET.Models.ProjectEmployee>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.RelationType>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.InvoiceLine>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.ProjectServiceLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.VatClassLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.SalesProgressLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.SalesStatusLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.ProjectLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.PersonLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.OrganizationContact>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.EmployeeLookup>().Namespace = name;

    builder.Namespace = name;

    return builder.GetEdmModel();
}


public class ODataOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

        var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

        if (descriptor != null && descriptor.FilterDescriptors.Any(filter => filter.Filter is Microsoft.AspNetCore.OData.Query.EnableQueryAttribute))
        {
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$filter",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Description = "Filter the response with OData filter queries.",
                Required = false
            });

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "$orderby",
                In = ParameterLocation.Query,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                },
                Description = "Define the order by one or more fields.",
                Required = false
            });

        }
    }
}

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is SimplicateResponseException httpResponseException)
        {
            context.Result = new ObjectResult(httpResponseException.Value)
            {
                StatusCode = httpResponseException.StatusCode,
            };

            context.ExceptionHandled = true;
        }
    }
}