﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Events;
using TravelManagement.Domain.Exceptions;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Domain;

namespace TravelManagement.Domain.Entities
{
	public class TravelerCheckList : AggregateRoot<TravelerCheckList>
	{
		public TravelerCheckListId Id { get; private set; }

		private TravelerCheckListName _name;

		private TravelerCheckListDestination _destination;

		private readonly LinkedList<TravelerItem> _items = new();

		public TravelerCheckList()
		{
		} 

		internal TravelerCheckList(
			TravelerCheckListId id,
			TravelerCheckListName name,
			TravelerCheckListDestination destination)
		{
			Id = id;
			_name = name;
			_destination = destination;
		}

		private TravelerCheckList(
			TravelerCheckListId id,
			TravelerCheckListName name,
			TravelerCheckListDestination destination,
			LinkedList<TravelerItem> items
			) : this(id, name, destination)
		{
			_items = items;
		}

		public void AddItem(TravelerItem item)
		{
			if (_items.Any(s => s.Name == item.Name))
			{
				throw new TravelerItemAlreadyExistsException(_name, item.Name);
			}

			_items.AddLast(item);

			AddEvent(new TravelerItemAdded(this, item));
		}

		public void AddItems(IEnumerable<TravelerItem> items)
		{
			foreach (var item in items)
			{
				AddItem(item);
			}
		}

		public void TakeItem(string itemName)
		{
			var item = GetItem(itemName);
			var TravelerItem = item with { IsTaken = true };

			_items.Find(item).Value = TravelerItem;

			AddEvent(new TravelerItemTaken(this, item));
		}

		private TravelerItem GetItem(string itemName)
		{
			var item = _items.SingleOrDefault(s => s.Name == itemName);

			if (item is null)
			{
				throw new TravelerItemNotFoundException(itemName);
			}

			return item;
		}

		private void RemoveItem(string itemName)
		{
			var item = GetItem(itemName);
			_items.Remove(item);

			AddEvent(new TravelerItemRemoved(this, item));
		}

	}
}
