﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Shared.Abstractions.Domain
{
	public abstract class AggregateRoot<T>
	{
		public T Id { get; protected set; }

		public int Version { get; protected set; }

		private bool _versionIncremented;

		protected void IncreamentVersion()
		{
			if (_versionIncremented)
			{
				return;
			}

			Version++;
			_versionIncremented = true;
		}
	}
}