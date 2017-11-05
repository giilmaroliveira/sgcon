using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PolicyTypeEnum
    {
        [EnumMember(Value = "Menu")]
        Menu,
        [EnumMember(Value = "SubMenu")]
        SubMenu,
        [EnumMember(Value = "Action")]
        Action,
        [EnumMember(Value = "Route")]
        Route

    }
}
