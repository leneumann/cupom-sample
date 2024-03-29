using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CupomSample.Api.Middlewares
{
     public static class SerializerSettings
    {
        public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}