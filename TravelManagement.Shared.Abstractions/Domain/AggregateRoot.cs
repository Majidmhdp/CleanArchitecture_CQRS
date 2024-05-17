using System;
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

		public IEnumerable<IDomainEvent> Events => _events;

		private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

		protected void AddEvent(IDomainEvent @events)
		{
			if (!_events.Any() && !_versionIncremented)
			{
				Version++;
				_versionIncremented = true;
			}

			_events.Add(@events);
		}

		public void ClearEvents() => _events.Clear();

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
