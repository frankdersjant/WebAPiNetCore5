using Microsoft.OpenApi.Models;

namespace WebAPiNetcore5.Installers
{
    internal class ApiKeyScheme : OpenApiSecurityScheme
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string In { get; set; }
        public string Type { get; set; }
    }
}