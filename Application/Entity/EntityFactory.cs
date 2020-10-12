using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class EntityFactory<T> where T : BaseEntity, new()
    {
        public static EntityFactory<T> Singleton
        {
            get
            {
                return new EntityFactory<T>();
            }
        }

        public T Create()
        {
            T entity = new T();
            entity.ID = Guid.NewGuid().ToString().Replace("-", "");
            return entity;
        }
    }
}
