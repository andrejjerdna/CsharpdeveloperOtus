using System.Dynamic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Reflection
{
        class F
        {
            [JsonProperty]
                int i1, i2, i3, i4, i5;

                public static F Get()
                {
                    return new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
                }
        }
}