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

using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net.Http.Headers;

var odataPath = "odata";
var apiVersion = "v2";

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, apiVersion, odataPath);

var app = builder.Build();

ConfigureApp(app, apiVersion);

app.Run();

// Configure the application services
void ConfigureServices(IServiceCollection services, string apiVersion, string odataPath)
{
    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc(apiVersion, new OpenApiInfo { Title = "Simplicator", Version = apiVersion });
        c.EnableAnnotations();

        c.DocInclusionPredicate((docName, apiDesc) =>
        {
            bool isODataEndpoint = apiDesc.RelativePath?.Contains(odataPath) == true;
            return isODataEndpoint == (docName == odataPath);
        });

        ConfigureSwaggerSecurity(c);

        c.OperationFilter<ODataOperationFilter>();
    });

    services.AddHttpClient<SimplicateClient>(client =>
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    });

    services.AddScoped<SimplicateService>();
    services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

    services.AddControllers(options =>
    {
        options.Filters.Add(new HttpResponseExceptionFilter());
    }).AddOData(oDataOptions => ConfigureOData(oDataOptions, "Simplicator", odataPath));
}


// Configure Swagger security
void ConfigureSwaggerSecurity(SwaggerGenOptions c)
{
    c.AddSecurityDefinition("API Key", new OpenApiSecurityScheme
    {
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "The API key for Simplicate"
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
}

// Configure the application
void ConfigureApp(WebApplication app, string apiVersion)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseHsts();
    }

    if (!app.Environment.IsProduction())
    {
        app.UseSwagger(options =>
        {
            options.SerializeAsV2 = true;
        });

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", "Simplicator");
        });
    }

    app.UseHttpsRedirection();

    app.MapControllers();
}

static void ConfigureOData(ODataOptions oDataOptions, string modelPrefix, string odataEndpoint)
{
    oDataOptions.AddRouteComponents(odataEndpoint, GetGraphModel(modelPrefix));
    oDataOptions.Filter().Select().Expand().OrderBy().Count().SetMaxTop(999).SkipToken();
}

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
    builder.EntitySet<Simplicate.NET.Models.QuoteTemplate>("QuoteTemplates").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Invoice>("Invoices").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.VatClass>("VatClasses").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.TimeTable>("TimeTables").EntityType.Namespace = name;
    builder.EntitySet<Simplicate.NET.Models.Leave>("Leaves").EntityType.Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.Avatar>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.MyOrganizationLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.NameLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.Address>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.LinkedProject>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.TypeLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.Address>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.LabelTypeLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.CustomField>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.QuoteStatusLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.QuoteTemplateLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.ProjectEmployee>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.RelationType>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.InvoiceLine>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.ProjectStatusLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.ProjectServiceLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.VatClassLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.SalesProgressLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.SalesStatusLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.ProjectLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.PersonLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.OrganizationContact>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.EmployeeLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.RevenueGroupLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.LeaveTypeLookup>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.TimeTableWeek>().Namespace = name;
    builder.ComplexType<Simplicate.NET.Models.TimeTableDay>().Namespace = name;

    builder.Namespace = name;

    return builder.GetEdmModel();
}

/// <summary>
/// Adds OData query parameters to the OpenAPI documentation for actions with the EnableQuery attribute.
/// </summary>
public class ODataOperationFilter : IOperationFilter
{
    /// <summary>
    /// Applies the ODataOperationFilter to the specified operation and context.
    /// </summary>
    /// <param name="operation">The OpenApiOperation to apply the filter to.</param>
    /// <param name="context">The OperationFilterContext containing metadata about the operation.</param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

        var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

        if (descriptor != null && descriptor.FilterDescriptors.Any(filter => filter.Filter is Microsoft.AspNetCore.OData.Query.EnableQueryAttribute))
        {
            operation.Parameters.Add(CreateODataParameter("$filter", "Filter the response with OData filter queries."));
            operation.Parameters.Add(CreateODataParameter("$orderby", "Define the order by one or more fields."));
        }
    }

    /// <summary>
    /// Creates an OpenApiParameter instance for an OData query parameter.
    /// </summary>
    /// <param name="name">The name of the OData query parameter.</param>
    /// <param name="description">The description of the OData query parameter.</param>
    /// <returns>An OpenApiParameter instance representing the OData query parameter.</returns>
    private OpenApiParameter CreateODataParameter(string name, string description)
    {
        return new OpenApiParameter()
        {
            Name = name,
            In = ParameterLocation.Query,
            Schema = new OpenApiSchema
            {
                Type = "string",
            },
            Description = description,
            Required = false
        };
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
