using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20
{
    internal class Decanat : EntityStorage<Student>
    {
        
    }

    /// <summary>
    /// Описание абстрактного класса, который наследуется от предыдущего, передавая
    /// свой параметр. Тип может быть как классом так и структурой(обозначить после where).
    /// С помощью этого можно задавать свои ограничения
    /// </summary>
    /// <typeparam name="IEntity"></typeparam>
    internal abstract class EntityStorage<TEntity> : Storage<TEntity>
        where TEntity : IEntity
    {
        private int _MaxId = 1;
        public override void Add(TEntity item)
        {
            item.Id = _MaxId++;
            base.Add(item);
        }
    }
}
