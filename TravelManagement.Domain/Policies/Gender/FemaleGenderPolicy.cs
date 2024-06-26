﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies.Gender
{
	internal sealed class FemaleGenderPolicy : ITravelerItemsPolicy
	{
		public bool IsApplicable(PolicyData data) => data.Gender is TravelManagement.Domain.Consts.Gender.Female;

		public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
			=> new List<TravelerItem>
			{
				new("Lipstick", 1),
				new("Powder", 1),
				new("Eyeliner", 1)
			};
	}
}
