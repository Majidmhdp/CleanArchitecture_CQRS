using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers
{
	internal sealed class RemoveTravelerCheckListHandler : ICommandHandler<RemoveTravelerCheckList>
	{
		private readonly ITravelerCheckListRepository _repository;

		public RemoveTravelerCheckListHandler(ITravelerCheckListRepository repository) => _repository = repository;

		public async Task HandleAsync(RemoveTravelerCheckList command)
		{
			var travelerCheckList = await _repository.GetAsync(command.Id);

			if (travelerCheckList is null)
			{
				throw new TravelerCheckListNotFound(command.Id);
			}

			await _repository.DeleteAsync(travelerCheckList);
		}

	}
}
