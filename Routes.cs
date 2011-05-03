using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace GBusManager
{


    public class RoutesEventArgs : EventArgs
    {
        public Route route;

        public RoutesEventArgs(Route r)
        {
            route = r;
        }

    }

    public delegate void RouteHandler(object sender, RoutesEventArgs e);

    /// <summary>
    /// Контейнер для маршрутов, начал делать
    /// </summary>
    class Routes:IList<Route>,ICollection<Route>
    {
        public Route[] routes;

        int cnt;

        int capacity;

        public event RouteHandler RouteAdded;
        //public event PointHandler PointAdded;

        public Routes(int capacity)
        {
            cnt = 0;
            this.capacity = capacity;
            routes = new Route[capacity];
            Status.myPoints.PointDeleted += new PointHandler(myPoints_PointDeleted);
        }

        protected virtual void OnRouteAdded(RoutesEventArgs e)
        {
            RouteAdded(this, e);
        }



        void myPoints_PointDeleted(object sender, PointsEventArgs e)
        {
            Console.WriteLine("Routes понял, что была удалена точка");
            for (int i = 0; i<= cnt; i++)
            {
                Route r = routes[i];
                if (r != null)
                {
                    /*
                    if (r.Contains(e.point.N))
                    {
                        Console.WriteLine("Маршрут {0} содержит {1}, удаляю", r, e.point);
                        r.DeleteFromRoute(e.point.N);
                        r = new Route(r.rs);
                        Console.WriteLine("Теперь маршрут стал {0}", r);


                    }
                     */ 
                }
            
            }
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

        #region Члены ICollection<Route>

        void ICollection<Route>.Add(Route item)
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

        void ICollection<Route>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<Route>.Contains(Route item)
        {
            throw new NotImplementedException();
        }

        void ICollection<Route>.CopyTo(Route[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        int ICollection<Route>.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<Route>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<Route>.Remove(Route item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Члены IEnumerable<Route>

        IEnumerator<Route> IEnumerable<Route>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

     
    }
}
