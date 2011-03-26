using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GBusManager
{
    /*
    public class ViewEventArgs : EventArgs
    {
        public GState State;
        public System.Collections.ArrayList Routes;
    }

    public delegate void ViewEventHandler(object sender, ViewEventArgs e);
    */

    static class Status
    {
        /*

        public event ViewEventHandler ViewEvent;

        protected virtual void OnViewEvent(ViewEventArgs e)
        {
            ViewEvent(this, e);
        }

        public enum GState
        {
            OnlyNodes,
            NodesAndRoutes,
            RouteDraw,
            ResultPath
        }

        State state;

        public State State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                ViewEventArgs vea = new ViewEventArgs();
                vea.State = value;
                if (value == GState.NodesAndRoutes)
                {
                    OnViewEvent(vea);
                }
            }
        }
        */

        public static Misc.Mode mode = Misc.Mode.Point;

        public static int x1;
        public static int y1;

        public static Point s;

        public static ArrayList Routes;

        public static ArrayList Points = new ArrayList();

        public static ArrayList Edges = new ArrayList();

        public static ToolsPanel tp;

        public static GraphCreator graphcreator;

        public static int x;
        public static int y;

        public static String crs;

        public static bool DEBUG = false;

        public static bool ElEd = false;
    }
}
