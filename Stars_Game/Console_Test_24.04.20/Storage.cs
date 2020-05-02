using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20
{
    /// <summary>
    /// Пример шаблона с угловыми скобками для перечисления 
    /// имен классов для дальнейшей работы
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public abstract class Storage<TItem>
    {
        private readonly List<TItem> _Items = new List<TItem>();

        public int Count => _Items.Count;

        public TItem this[int index]
        {
            get
            {
                return _Items[index];
            }

            set
            {
                if (_Items.Contains(value)) return;
                _Items[index] = value;
            }
        }

        public void Add(TItem item)
        {
            if (_Items.Contains(item)) return;
            _Items.Add(item);
        }

        public bool Remove(TItem item)
        {
            return _Items.Remove(item);
        }

        public bool IsContains(TItem item)
        {
            return _Items.Contains(item);
        }

        public void Clear()
        {
            _Items.Clear();
        }
    }
}
