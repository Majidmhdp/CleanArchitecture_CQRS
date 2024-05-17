using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies
{
	public interface ITravelerItemsPolicy
	{
		bool IsApplicable(PolicyData data);

		IEnumerable<TravelerItem> GenerateItems(PolicyData data);
	}
}
