using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GBusManager
{
 

    static class Status
    {
       

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

        public static bool ElEd = true;

        public static Points myPoints = new Points(10);

        public static Routes myRoutes;
    }
}
