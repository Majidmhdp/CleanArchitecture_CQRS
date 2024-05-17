using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Exceptions;

namespace TravelManagement.Domain.ValueObjects
{
	public record TravelerCheckListDestination(string City, string Country)
	{

		public static TravelerCheckListDestination Create(string value)
		{
			var split = value.Split(',');
			return new TravelerCheckListDestination(split.First(), split.Last());
		}

		public override string ToString() => $"{City},{Country}";
	}
}
