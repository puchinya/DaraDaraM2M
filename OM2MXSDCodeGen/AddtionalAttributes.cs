using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace OM2MXSDCodeGen
{
    public class AddtionalAttributes
    {
        [JsonProperty("types")]
        public List<AAType> Types
		{
			get;
			set;
		}

        public static AddtionalAttributes Parse(string json)
        {
            return JsonConvert.DeserializeObject<AddtionalAttributes>(json);
        }
    }

    public class AAType
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("attributes")]
        public List<AAAttribute> Attributes
        {
            get;
            set;
        }
    }

    public class AAAttribute
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("create")]
        public Optionality Create
        {
            get;
            set;
        }

        [JsonProperty("update")]
        public Optionality Update
        {
            get;
            set;
        }
    }

    public enum Optionality
    {
        O,
        NP,
        M
    }
}
