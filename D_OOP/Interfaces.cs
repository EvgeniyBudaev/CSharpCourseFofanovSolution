using System.Collections.Generic;

namespace D_OOP
{
    // Нельзя создать экземпляр интерфейса, нельзя создать конструктор и поле
    // Можно наследоваться от нескольких интерфейсов
    public interface IBaseCollection
    {
        void Add(object obj);
        void Remove(object obj);
    }

    public static class BaseCollectionExtension
    {
        // IEnumerable - интерфейс, имплементоры которого, т.е те классы которые мы иплементируем позволяют по ним делать по инстанциям foreach
        public static void AddRange(this IBaseCollection collection, IEnumerable<object> objects)
        {
            foreach(var item in objects)
            {
                collection.Add(item);
            }
        }
    }

    public class BaseList : IBaseCollection
    {
        private object[] items;
        private int count = 0;

        public BaseList(int initialCapacity)
        {
            items = new object[initialCapacity];
        }

        void IBaseCollection.Add(object obj)
        {
            items[count] = obj;
            count++;
        }

        void IBaseCollection.Remove(object obj)
        {
            items[count] = null;
            count--;
        }
    }
}