using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20
{
    /// <summary>Хранилище
    /// "Фасад" - прячем объект внутри класса обеспечивая 
    /// необходимый доступ к нему.
    /// Пример шаблона с угловыми скобками для перечисления 
    /// имен классов для дальнейшей работы. </summary>
    internal abstract class Storage<TItem> : IEnumerable<TItem>//благодаря интерфейсу IEnumerable можно использовать заданный класс как источник данных для цикла foreach
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

        public virtual void Add(TItem item)
        {
            if (_Items.Contains(item)) return;
            _Items.Add(item);
        }

        public virtual bool Remove(TItem item)
        {
            return _Items.Remove(item);
        }

        public virtual bool IsContains(TItem item)
        {
            return _Items.Contains(item);
        }

        public virtual void Clear()
        {
            _Items.Clear();
        }

        /// <summary>
        /// Реализация 2-х методов получения перечислителя объекта 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TItem> GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
