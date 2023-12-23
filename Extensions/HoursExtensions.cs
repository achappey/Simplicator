using Simplicate.NET.Models;
using Simplicator.Models;

namespace Simplicator.Extensions
{
    public static class HoursExtensions
    {
        public static Models.Hours ToSimplicatorHours(this Simplicate.NET.Models.Hours hours)
        {
            return new Models.Hours
            {
                Id = hours.Id,
                ProjectServiceId = hours.ProjectService?.Id,
                InvoiceStatus = hours.InvoiceStatus,
                StartDate = hours.StartDate,
                EndDate = hours.EndDate,
                Time = hours.Time,
                Tariff = hours.Tariff,
                Billable = hours.Billable,
                Status = hours.Status,
                Note = hours.Note,
                EmployeeWorkEmail = hours.EmployeeWorkEmail
            };
        }
    }
}
