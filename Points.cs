using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBusManager
{   
    /// <summary>
    /// Контейнер для точек с операциями доступа 
    /// </summary>
    /// TODO
    class Points:ICollection<Point>,IList<Point>
    {

        #region Члены ICollection<Point>

        public void Add(Point item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Point item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Point[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Point item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Члены IEnumerable<Point>

        public IEnumerator<Point> GetEnumerator()
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

        #region Члены IList<Point>

        public int IndexOf(Point item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Point item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Point this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
