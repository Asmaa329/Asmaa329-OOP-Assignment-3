using Generics.src;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Generics
{
    public class Store<T>
    {
        private readonly List<T> _items = new();
        public void Add(T item)
        {
            _items.Add(item);
        }
        //public T? GetById(int id)
        //{
        //    foreach (var item in _items)
        //    {
        //        if (item.Id == id)
        //        {
        //            return item;
        //        }
        //    }

        //    return null;
        //}

        public List<T> GetAll()
        {
            return _items;
        }
        //public bool Remove(int id)
        //{
        //    var item = GetById(id);
        //    if (item != null)
        //    {
        //        return _items.Remove(item);
        //    }
        //    return false;
        //}
    }
}
