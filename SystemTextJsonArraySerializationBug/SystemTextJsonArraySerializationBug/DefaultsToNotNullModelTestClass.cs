using System;
using System.Collections.Generic;
using System.Text;

namespace SystemTextJsonArraySerializationBug
{
	public class DefaultsToNotNullModelTestClass
	{
		public string[] ArrayProperty { get; set; } = Array.Empty<string>();
	}
}
