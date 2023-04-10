using Simplicator.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Simplicator.Extensions;

public static class HttpExtensions
{
    public static User GetUser(this ControllerBase context)
    {
        var header = context.Request.Headers["x-api-key"].FirstOrDefault() ??
                        context.Request.Query["x-api-key"].FirstOrDefault();

        if (!string.IsNullOrEmpty(header))
        {
            var decoded = header.DecodeBase64();

            if (decoded.Split('@') is { Length: 2 } items &&
                             items.First().Split(':') is { Length: 2 } access)
            {
                return new User( items.Last(), access.First(), access.Last());
            }

        }

        throw new UnauthorizedAccessException();
    }

    public static string DecodeBase64(this string value)
    {
        var valueBytes = Convert.FromBase64String(value);

        return Encoding.UTF8.GetString(valueBytes);
    }

    public static string EncodeBase64(this string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        return Convert.ToBase64String(plainTextBytes);
    }
}