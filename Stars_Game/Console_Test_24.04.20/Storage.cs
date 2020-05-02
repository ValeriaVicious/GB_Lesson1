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
        private Action<TItem> _AddObservers;//в одну переменную делегата можно положить большое кол-во методов

        public event Action<TItem> ITemRemoved;
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

        public void SubscribeToAdd(Action<TItem> Observer)
        {
            _AddObservers += Observer;
        }

        public virtual void Add(TItem item)
        {
            if (_Items.Contains(item)) return;
            _Items.Add(item);

            if (_AddObservers != null)
                _AddObservers(item);
        }

        public virtual bool Remove(TItem item)
        {
            bool result = _Items.Remove(item);

            if(result)
            {
                ITemRemoved?.Invoke(item);
            }

            return result;
        }

        public virtual bool IsContains(TItem item)
        {
            return _Items.Contains(item);
        }

        public virtual void Clear()
        {
            _Items.Clear();
        }

        public abstract void SaveToFile(string FileName);
        public virtual void LoadFromFile(string FileName)
        {
            Clear();
        }

        ///<summary>Реализация 2-х методов получения перечислителя объекта</summary>
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
