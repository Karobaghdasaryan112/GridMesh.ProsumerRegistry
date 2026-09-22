namespace GridMesh.ProsumerRegistry.Infrastructure.Logging
{

    internal static class LogLayerResolver
    {
        public static string Resolve(string categoryName)
        {
            if (categoryName.Contains(".Api.") || categoryName.Contains(".Controllers."))
                return "Presentation";
            if (categoryName.Contains(".Application."))
                return "Application";
            if (categoryName.Contains(".Persistance.") || categoryName.Contains(".Infrastructure."))
                return "Persistence";
            if (categoryName.Contains(".Domain."))
                return "Domain";
            return "Unknown";
        }
    }
}