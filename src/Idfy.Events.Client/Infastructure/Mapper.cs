using System.Reflection;
using Newtonsoft.Json;

namespace Idfy.Events.Client.Infastructure
{
    internal static class Mapper<T>
    {
        public static T MapFromJson(IdfyResponse idfyResponse)
        {
            return MapFromJson(idfyResponse.ResponseJson, idfyResponse);
        }

        public static T MapFromJson(string json, IdfyResponse idfyResponse = null)
        {
            var result = JsonConvert.DeserializeObject<T>(json);

            if (idfyResponse == null) return result;
            
            foreach (var prop in result.GetType().GetRuntimeProperties())
            {
                if (prop.Name == nameof(IdfyResponse))
                    prop.SetValue(result, idfyResponse);
            }

            return result;
        }
    }
}