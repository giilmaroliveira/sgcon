using Newtonsoft.Json.Converters;   

namespace SgConAPI.Utils
{
    public class CustomDateConverter : IsoDateTimeConverter
    {
        public CustomDateConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
