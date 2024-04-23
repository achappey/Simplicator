namespace Simplicate.NET
{
    public static class Endpoints
    {
        public const string ApiUrlFormat = "https://{0}.simplicate.com/api/v2/";

        public static class Crm
        {
            public const string Organization = "crm/organization";
            public const string MyOrganization = "crm/myorganizationprofile";
            public const string Person = "crm/person";
            public const string ContactPerson = "crm/contactperson";
            public const string Industry = "crm/industry";
            public const string Interests = "crm/interests";
        }

        public static class Hrm
        {
            public const string Employee = "hrm/employee";
            public const string Contract = "hrm/contract";
            public const string Leave = "hrm/leave";
            public const string TimeTable = "hrm/timetable";
        }

        public static class Projects
        {
            public const string Project = "projects/project";
            public const string ProjectEmployee = "projects/projectemployee";
            public const string Service = "projects/service";
            public const string ProjectStatus = "projects/projectstatus";
        }

        public static class SalesInfo
        {
            public const string Sales = "sales/sales";
            public const string Service = "sales/service";
            public const string Quote = "sales/quote";
            public const string QuoteStatus = "sales/quotestatus";
            public const string QuoteTemplate = "sales/quotetemplate";
            public const string SalesStatus = "sales/salesstatus";
            public const string SalesSource = "sales/salessource";
            public const string SalesProgress = "sales/salesprogress";
            public const string RevenueGroup = "sales/revenuegroup";
        }

        public static class Invoices
        {
            public const string Invoice = "invoices/invoice";
            public const string InvoiceStatus = "invoices/invoicestatus";
            public const string VatClass = "invoices/vatclass";
        }

        public static class Services
        {
            public const string DefaultService = "services/defaultservice";
        }

        public static class Hours
        {
            public const string TimeEntry = "hours/hours";
        }

        public static string GetApiUrl(string subdomain)
        {
            return string.Format(ApiUrlFormat, subdomain);
        }
    }
}
