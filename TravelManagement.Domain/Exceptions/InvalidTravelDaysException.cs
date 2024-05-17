using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions
{
	internal class InvalidTravelDaysException : TravelerCheckListException
	{
		public ushort Days { get; }

		public InvalidTravelDaysException(ushort days) : 
			base($"Value '{days}' is invalid") => Days = days;
	}
}
