using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.DTO.External;

namespace TravelManagement.Application.Services
{
	public interface IWeatherService
	{
		Task<WeatherDto> GetWeatherAsync(Domain.ValueObjects.TravelerCheckListDestination localization);
	}
}
