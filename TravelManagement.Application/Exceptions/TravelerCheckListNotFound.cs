using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions
{
	public class TravelerCheckListNotFound : TravelerCheckListException
	{
		public Guid Id { get; }

		public TravelerCheckListNotFound(Guid id) : base($"Traveler Check list with id '{id}'")
			=> Id = id;
	}
}
