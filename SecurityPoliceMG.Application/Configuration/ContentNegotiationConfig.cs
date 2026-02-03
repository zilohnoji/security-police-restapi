using Microsoft.Net.Http.Headers;

namespace SecurityPoliceMG.Configuration;

public static class ContentNegotiationConfig
{
    public static IMvcBuilder ConfigureContentNegotiation(this IMvcBuilder builder)
    {
        return builder.AddMvcOptions(options =>
        {
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;

            // Acceptable Types => XML | TextJson
            options.FormatterMappings.SetMediaTypeMappingForFormat(
                "xml", MediaTypeHeaderValue.Parse("application/xml"));

            options.FormatterMappings.SetMediaTypeMappingForFormat(
                "json", MediaTypeHeaderValue.Parse("application/json"));
        }).AddXmlDataContractSerializerFormatters();
    }
}