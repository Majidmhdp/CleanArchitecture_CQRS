using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands
{
	public record CreateTravelerCheckListsWithItems(Guid Id, string Name, ushort Days, Gender Gender,
		DestinationWriteModel Destination) : ICommand;

	public record DestinationWriteModel(string City, string Country);

}
