using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBusManager
{
    /// <summary>
    /// Контейнер для маршрутов, начал делать
    /// </summary>
    class Routes:ICollection<Route>,IList<Route>
    {
        Route[] routes;

        int cnt;

        int capacity;

        public Routes(int capacity)
        {
            cnt = 0;
            this.capacity = capacity;
            routes = new Route[capacity];
        }


        #region Члены ICollection<Route>

        public void Add(Route item)
        {
            if (cnt == capacity)
            {
                Console.WriteLine("Нужно увеличить емкость Routes");
                capacity = capacity * 2;
                Route[] newroutes = new Route[capacity];
                
                for (int i = 0; i < routes.Length; i++)
                {
                    newroutes[i] = routes[i];
                }
                routes = newroutes;

            }

            routes[cnt++] = item;
        }

        public void Clear()
        {
            cnt = 0;
            routes = new Route[capacity];
        }

        public bool Contains(Route item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Route[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return cnt; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Route item)
        {
            for (int i = 0; i < cnt; i++)
            {
                if (routes[i] == item)
                {

                    routes[i] = null;
                    return true;
                }
                
            }
            return false;
        }

        #endregion

        #region Члены IEnumerable<Route>

        public IEnumerator<Route> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Члены IEnumerable

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Члены IList<Route>

        public int IndexOf(Route item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Route item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Route this[int index]
        {
            get
            {
                if (index <= capacity)
                {
                    return routes[index];
                }
                else throw new IndexOutOfRangeException();

            }
            set
            {
                if (index <= capacity)
                {
                    routes[index] = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}
