using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace GBusManager
{

   
 public class PointsEventArgs : EventArgs
 {
     public Point point;

     public PointsEventArgs(Point p)
     {
         point = p;
     }
     
 }

 public delegate void PointHandler(object sender, PointsEventArgs e);
 

    /// <summary>
    /// Контейнер для точек с операциями доступа и событиями
    /// </summary>
    /// TODO
    class Points:ICollection<Point>,IList<Point>
    {

        

       public event PointHandler PointAdded;
       public event PointHandler PointDeleted;

       protected virtual void OnPointAdded(PointsEventArgs e)
       {
           //PointsEventArgs pea = new PointsEventArgs(points[cnt]);
           //pea.p = points[cnt];
           Console.WriteLine("Была добавлена точка {0}", e.point.ToString());
           PointAdded(this, e);
       }


       protected virtual void OnPointDeleted(PointsEventArgs e)
       {
           //PointsEventArgs pea = new PointsEventArgs(points[cnt]);
           //pea.p = points[cnt];
           Console.WriteLine("Была удалена точка {0}", e.point.ToString());
           PointDeleted(this, e);
       }


      

        Point[] points;

        //ArrayList<Point> p;

        int capacity;

        int cnt;

        public Points(int capacity)
        {
            cnt = 0;
            points = new Point[capacity];
            this.capacity = capacity;
        }

        #region Члены ICollection<Point>

        public void Add(Point item)
        {
            if (cnt == capacity)
            {
                Console.WriteLine("Нужно увеличить емкость Points");
                capacity = capacity * 2;
                Point[] newpoints = new Point[capacity];

                for (int i = 0; i < points.Length; i++)
                {
                    newpoints[i] = points[i];
                }
                points = newpoints;

            }

            points[cnt++] = item;

            OnPointAdded(new PointsEventArgs(item));
        }

        public void Clear()
        {
            cnt = 0;
            points = new Point[capacity];
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
            get { return cnt; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Point item)
        {
            for (int i = 0; i < cnt; i++)
            {
                if (points[i] == item)
                {
                    points[i] = null;
                    OnPointDeleted(new PointsEventArgs(item));
                    return true;
                }

            }
            return false;
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
                if (index <= capacity)
                {
                    return points[index];
                }
                else throw new IndexOutOfRangeException();
                
            }
            set
            {
                if (index <= capacity)
                {
                    points[index] = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}
