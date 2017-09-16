using System;
using System.Reflection;

namespace DaraDaraM2M.Data
{
    public class OM2MRequestOptionalityAttribute : Attribute
    {
        public OM2MRequestOptionalityAttribute(
            OM2MRequestOptionality create,
            OM2MRequestOptionality update)
        {
            Create = create;
            Update = update;
        }

        public OM2MRequestOptionality Create
        {
            get;
        }

        public OM2MRequestOptionality Update
        {
            get;
        }

        public static void CheckRequestOptionality(object obj, bool isCreate)
        {
            var type = obj.GetType();
            foreach(var property in type.GetProperties())
            {
                var attr = property.GetCustomAttribute<OM2MRequestOptionalityAttribute>();
                if(attr != null) {
                    var val = property.GetValue(obj);
                    var rq = isCreate ? attr.Create : attr.Update;
                    if(rq == OM2MRequestOptionality.NotPresent) {
                        if(val != null) {
                            throw new OM2MBadRequestException($"{property.Name} is not permitted.");
                        }
                    }
                    else if(rq == OM2MRequestOptionality.Mandatory)
                    {
						if (val == null)
						{
							throw new OM2MBadRequestException($"{property.Name} is mandatory.");
						}
                    }
                }
            }
        }
    }

    public enum OM2MRequestOptionality
    {
        Optional,
        Mandatory,
        NotPresent
	}
}
