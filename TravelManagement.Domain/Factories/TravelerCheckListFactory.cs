using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Policies;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories
{
	public sealed class TravelerCheckListFactory : ITravelerCheckListFactory
	{

		private readonly IEnumerable<ITravelerItemsPolicy> _policies;

		public TravelerCheckListFactory(IEnumerable<ITravelerItemsPolicy> policies)
			=> _policies = policies;


		public TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name,
			TravelerCheckListDestination destination)
			=> new(id, name, destination);


		public TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name,
			TravelerCheckListDestination destination, TravelDays days, Gender gender, Temperature temperature)
		{
			var data = new PolicyData(days, gender, temperature, destination);
			var applicablePolicies = _policies.Where(s => s.IsApplicable(data));

			var items = applicablePolicies.SelectMany(s => s.GenerateItems(data));
			var travelerCheckingList = Create(id, name, destination);

			travelerCheckingList.AddItems(items);

			return travelerCheckingList;
		}
	}
}
