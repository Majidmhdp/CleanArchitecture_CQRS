using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers
{
	internal sealed class RemoveTravelerItemsHandler : ICommandHandler<RemoveTravelerItem>
	{
		private readonly ITravelerCheckListRepository _repository;

		public RemoveTravelerItemsHandler(ITravelerCheckListRepository repository) => _repository = repository;

		public async Task HandleAsync(RemoveTravelerItem command)
		{
			var travelerCheckList = await _repository.GetAsync(command.TravelerCheckListId);

			if (travelerCheckList is null)
			{
				throw new TravelerCheckListNotFound(command.TravelerCheckListId);
			}

			travelerCheckList.RemoveItem(command.Name);

			await _repository.UpdateAsync(travelerCheckList);
		}
	}
}
