using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GBusManager
{
    static class SaveLoad
    {
        static Stream stream; //= File.Open("EmployeeInfo.osl", FileMode.Create);
        static BinaryFormatter bformatter; // = new BinaryFormatter();

        //Stream stream = File.Open("EmployeeInfo.osl", FileMode.Create);

        public static void Save(){
            stream = File.Open("Points.bin", FileMode.Create);
            bformatter = new BinaryFormatter();
            Console.WriteLine("Writing Points Information");
            bformatter.Serialize(stream, Status.Points);
            stream.Close();

            stream = File.Open("Routes.bin", FileMode.Create);
            Console.WriteLine("Writing Routes Information");
            bformatter.Serialize(stream, Status.Routes);
            stream.Close();

            stream = File.Open("Edges.bin", FileMode.Create);
            Console.WriteLine("Writing Edges Information");
            bformatter.Serialize(stream, Status.graphcreator.edges);
            stream.Close();
        }

        public static void Load()
        {
            stream = File.Open("Points.bin", FileMode.Open);
            bformatter = new BinaryFormatter();

            Console.WriteLine("Reading Points Information: Begins");
            Status.Points = (System.Collections.ArrayList)bformatter.Deserialize(stream);
            Console.WriteLine("Reading Points Information: Completed");
            stream.Close();

            Status.graphcreator.points = Status.Points;

            stream = File.Open("Routes.bin", FileMode.Open);
            Console.WriteLine("Reading Routes Information: Begins");
            Status.Routes = (System.Collections.ArrayList)bformatter.Deserialize(stream);
            Console.WriteLine("Reading Routes Information: Completed");
            stream.Close();

            stream = File.Open("Edges.bin", FileMode.Open);
            Console.WriteLine("Reading Edges Information: Begins");
            Status.graphcreator.edges = (System.Collections.ArrayList)bformatter.Deserialize(stream);
            Status.Edges = Status.graphcreator.edges; //(System.Collections.ArrayList)bformatter.Deserialize(stream);
            Console.WriteLine("Reading Edges Information: Completed");
            stream.Close();



            Status.tp.routes = Status.Routes;
            Status.tp.RefreshRoutesAndPoints();
            Status.graphcreator.Redraw(true);
            Status.graphcreator.DrawRoutes(Status.Routes.ToArray(typeof(Route)) as Route[]);
            
        }
            





    }
}
