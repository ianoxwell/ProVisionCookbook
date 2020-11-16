using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pcb.Api.Helper
{
	/// <inheritdoc />
	public class InterfaceContractResolver<TInterface> :
		DefaultContractResolver
		where TInterface : class
	{
		/// <inheritdoc/>
		protected override IList<JsonProperty> CreateProperties(
			Type type,
			MemberSerialization memberSerialization)
		{
			// Create properties based purely on the interface
			var properties = base.CreateProperties(
				typeof(TInterface), memberSerialization);

			// Camel-case the property names
			foreach (var property in properties)
			{
				property.PropertyName = char.ToLower(property.PropertyName[0])
					+ string.Join(string.Empty, property.PropertyName.Skip(1));
			}

			return properties;
		}
	}
}
