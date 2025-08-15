using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3.Q2
{
    public class Repository<T>
    {
        private readonly List<T> items = new();

        public void Add(T item) => items.Add(item);
        public List<T> GetAll() => new(items);
        public T? GetById(Func<T, bool> predicate) => items.FirstOrDefault(predicate);
        public bool Remove(Func<T, bool> predicate)
        {
            var idx = items.FindIndex(x => predicate(x));
            if (idx >= 0)
            {
                items.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
