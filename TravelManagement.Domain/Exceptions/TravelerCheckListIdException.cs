using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions
{
	public class TravelerCheckListIdException : TravelerCheckListException
	{
		public TravelerCheckListIdException() : base("Traveler Checklist ID cannot be empty.")
		{
		}
	}
}
