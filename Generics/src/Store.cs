using Generics.src;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Generics
{
    public class Store<T> where T : IHasId
    {
        private readonly Dictionary<int, T> items = new();

        public void Add(T item)
        {
            if (items.ContainsKey(item.Id))
            {
                throw new InvalidOperationException($"item {item.Id} is already exist");
            }
            items.Add(item.Id, item);
        }

        public T? GetById(int id)
        {
            return items.TryGetValue(id, out var item) ? item : default;
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return items.Values;
        }

        public bool Remove(int id)
        {
            return items.Remove(id);
        }
    }
}
