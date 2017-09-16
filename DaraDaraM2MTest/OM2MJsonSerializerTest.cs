using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaraDaraM2M;
using DaraDaraM2M.Data;

namespace DaraDaraM2MTest
{
    [TestClass]
	public class OM2MJsonSerializerTest
	{
		[TestMethod]
		public void DeserializeTest1()
		{
			var content = "{\"m2m:rqp\":{\"op\":1,\"to\":\"//example.net/mncse1234\",\"rqi\":\"A1000\", \"rcn\":7,\"pc\":{\"m2m:ae\":{\"rn\":\"SmartHomeApplication\", \"api\":\"Na56\", \"apn\":\"app1234\"}},\"ty\":2}}";

			var rqpObj = OM2MJsonSerializer.Deserialize(content);

            Assert.IsInstanceOfType(rqpObj, typeof(OM2MRequestPrimitive));
            var rqp = rqpObj as OM2MRequestPrimitive;
            Assert.AreEqual(rqp.Operation, OM2MOperation.Create);
			Assert.AreEqual(rqp.RequestIdentifier, "A1000");
			Assert.AreEqual(rqp.ResourceType, OM2MResourceType.AE);
			Assert.AreEqual(rqp.ResultContent, OM2MResultContent.OriginalResource);


			Assert.IsInstanceOfType(rqp.PrimitiveContent.Any[0], typeof(OM2MAE));
			var ae = rqp.PrimitiveContent.Any[0] as OM2MAE;
			Assert.AreEqual(ae.AppName, "app1234");
			Assert.AreEqual(ae.AppID, "Na56");
			Assert.AreEqual(ae.ResourceName, "SmartHomeApplication");

			var text = OM2MJsonSerializer.Serialize(rqpObj);

			return;
		}
	}
}
