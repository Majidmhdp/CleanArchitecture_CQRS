using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies
{
	public record PolicyData(TravelDays Days, Consts.Gender Gender, ValueObjects.Temperature Temperature,
		TravelerCheckListDestination Destination);

}
