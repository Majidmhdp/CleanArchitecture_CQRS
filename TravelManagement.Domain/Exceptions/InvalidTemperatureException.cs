﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions
{
	public class InvalidTemperatureException : Exception
	{
		public double Value { get; }

		public InvalidTemperatureException(double value) : base($"Value '{value}' is invalid.")
			=> Value = value;
	}
}
