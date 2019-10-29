using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace SystemTextJsonArraySerializationBug
{
	[TestClass]
	public class ArrayDeserializationBugTest
	{
		[TestMethod]
		[DataTestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void Deserialize_GivenModelWithDefaultArrayPropertyOfNullAndArrayPropertyInJSON_DeserializesArrayProperty(bool ignoreNullValues)
		{
			// Arrange
			const string value1 = "value-1";
			const string value2 = "value-2";

			string json = $@"{{ ""ArrayProperty"": [""{value1}"", ""{value2}""] }}";
			JsonSerializerOptions jsonSerializerOptions = CreateOptions(ignoreNullValues);

			// Act
			DefaultsToNotNullModelTestClass result = JsonSerializer.Deserialize<DefaultsToNotNullModelTestClass>(json, jsonSerializerOptions);

			// Assert
			Assert.IsNotNull(result.ArrayProperty);
			Assert.AreEqual(result.ArrayProperty?.Length, 2);
			Assert.AreEqual(result.ArrayProperty?[0], value1);
			Assert.AreEqual(result.ArrayProperty?[1], value2);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void Deserialize_GivenModelWithDefaultArrayPropertyOfNullAndNoArrayPropertyInJSON_DeserializesArrayPropertyAsEmpty(bool ignoreNullValues)
		{
			// Arrange
			const string json = "{ }";
			JsonSerializerOptions jsonSerializerOptions = CreateOptions(ignoreNullValues);

			// Act
			DefaultsToNotNullModelTestClass result = JsonSerializer.Deserialize<DefaultsToNotNullModelTestClass>(json, jsonSerializerOptions);

			// Assert
			Assert.AreEqual(result.ArrayProperty.Length, 0);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void Deserialize_GivenModelWithDefaultArrayPropertyOfNotNullAndArrayPropertyInJSON_DeserializesArrayProperty(bool ignoreNullValues)
		{
			// Arrange
			const string value1 = "value-1";
			const string value2 = "value-2";

			string json = $@"{{ ""ArrayProperty"": [""{value1}"", ""{value2}""] }}";
			JsonSerializerOptions jsonSerializerOptions = CreateOptions(ignoreNullValues);

			// Act
			DefaultsToNotNullModelTestClass result = JsonSerializer.Deserialize<DefaultsToNotNullModelTestClass>(json, jsonSerializerOptions);

			// Assert
			Assert.IsNotNull(result.ArrayProperty);
			Assert.AreEqual(result.ArrayProperty.Length, 2);
			Assert.AreEqual(result.ArrayProperty[0], value1);
			Assert.AreEqual(result.ArrayProperty[1], value2);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void Deserialize_GivenModelWithDefaultArrayPropertyOfNotNullAndEmptyArrayPropertyInJSON_DeserializesArrayPropertyToEmpty(bool ignoreNullValues)
		{
			// Arrange
			string json = $@"{{ ""ArrayProperty"": [] }}";
			JsonSerializerOptions jsonSerializerOptions = CreateOptions(ignoreNullValues);

			// Act
			DefaultsToNotNullModelTestClass result = JsonSerializer.Deserialize<DefaultsToNotNullModelTestClass>(json, jsonSerializerOptions);

			// Assert
			Assert.IsNotNull(result.ArrayProperty);
			Assert.AreEqual(result.ArrayProperty.Length, 0);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void Deserialize_GivenModelWithDefaultArrayPropertyOfNotNullAndnullArrayPropertyInJSON_DeserializesArrayPropertyToEmpty(bool ignoreNullValues)
		{
			// Arrange
			const string json = "{ }";
			JsonSerializerOptions jsonSerializerOptions = CreateOptions(ignoreNullValues);

			// Act
			DefaultsToNotNullModelTestClass result = JsonSerializer.Deserialize<DefaultsToNotNullModelTestClass>(json, jsonSerializerOptions);

			// Assert
			Assert.IsNotNull(result.ArrayProperty);
			Assert.AreEqual(result.ArrayProperty.Length, 0);
		}

		static JsonSerializerOptions CreateOptions(bool ignoreNullValues)
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				IgnoreNullValues = ignoreNullValues
			};

			return options;
		}

	}
}
