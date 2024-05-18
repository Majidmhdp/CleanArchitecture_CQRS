using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions
{
	public class MissingDestinationWeatherException : TravelerCheckListException
	{
		public TravelerCheckListDestination Destination { get; }


		public MissingDestinationWeatherException(TravelerCheckListDestination destination)
			: base($"Coudn't fetch weather data for destination '{destination.Country}/{destination.City}'")
			=> Destination = destination;

	}
}
