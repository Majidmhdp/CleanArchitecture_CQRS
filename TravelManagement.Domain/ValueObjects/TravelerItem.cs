﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Exceptions;

namespace TravelManagement.Domain.ValueObjects
{
	public record TravelerItem
	{
		public TravelerItem(string name, uint quantity, bool isTaken = false)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new TravelerItemNameException();
			}

			Name = name;
			Quantity = quantity;
			IsTaken = isTaken;
		}

		public string Name { get; }

		public uint Quantity { get; }

		public bool IsTaken { get; init; }
	}
}
