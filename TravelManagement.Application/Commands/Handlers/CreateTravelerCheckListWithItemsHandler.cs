using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Exceptions;
using TravelManagement.Application.Services;
using TravelManagement.Domain.Factories;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers
{
	internal sealed class CreateTravelerCheckListWithItemsHandler : ICommandHandler<CreateTravelerCheckListsWithItems>
	{
		private readonly ITravelerCheckListRepository _repository;
		private readonly ITravelerCheckListFactory _factory;
		private readonly IWeatherService _weatherService;

		public CreateTravelerCheckListWithItemsHandler(ITravelerCheckListRepository repository, ITravelerCheckListFactory factory, IWeatherService weatherService)
		{
			_repository = repository;
			_factory = factory;
			_weatherService = weatherService;
		}

		public async Task HandleAsync(CreateTravelerCheckListsWithItems command)
		{
			var (id, name, dayes, gender, destinationWriteModel) = command;

			var destination =
				new TravelerCheckListDestination(destinationWriteModel.City, destinationWriteModel.Country);
			var weather = await _weatherService.GetWeatherAsync(destination);

			if (weather is null)
			{
				throw new MissingDestinationWeatherException(destination);
			}

			var travelerCheckList = _factory.CreateWithDefaultItems(id, name, destination, dayes, gender, weather.Temperature);

			await _repository.AddAsync(travelerCheckList);
		}
	}
}
