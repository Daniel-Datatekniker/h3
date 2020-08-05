using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Airport> airports = new List<Airport>() {
            //new Airport("AAL", "Aalborg", "Denmark" ),
            //new Airport("AAR", "Aarhus", "Denmark" ),
            //new Airport("ABD", "Abadan", "Persian" ),
            //new Airport("ABA", "Abakan", "Persian" ),
            //};

            //Ran out of time wanted to create more comments. took longer than exepected.

            Creator creator = new Creator();
            Api api = new Api();
            Plane plane = new Plane();


            while (true)
            {

                Console.WriteLine("Menu Options\n#0 add Airport route\n#1 add Destination\n#2 Add Airline\n#3 add timeline");
                int menuPress = -1;

                if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out menuPress))
                {
                    switch (menuPress)
                    {
                        //Going to split everything up in septerate cases, but time is short, trying to get the most out of it
                        case 0:
                            Console.Write("Input iata : ");
                            string inp = Console.ReadLine();
                            Console.Write("Input city : ");
                            string inp2 = Console.ReadLine();
                            Console.Write("Input country : ");
                            string inp3 = Console.ReadLine();
                            if (creator.AirportCreator(inp, inp2, inp3))
                                Console.WriteLine("sucess");
                            else
                                Console.WriteLine("Error");
                            //going to make him try again or something.



                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Input gate number:");
                            //Going to make a check for int32, but time is short moving on.
                            int gatenum = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("input Iata : ");
                            if (creator.DestinationCreator(Console.ReadLine(), gatenum))
                                Console.WriteLine("Success");
                            else
                                Console.WriteLine("Error");

                            //same as before, would be easier in a wpf, than i could look up the input data while writing, like a search bar and return a textbox saying doesnt exsist.


                            break;
                        case 2:
                            Console.Write("Input airline name : ");
                            if (creator.AirlineCreator(Console.ReadLine()))
                                Console.WriteLine("Success");
                            else
                                Console.WriteLine("Error");
                            break;
                        case 3:
                            try
                            {
                                Console.Write("Depature hours : ");
                                TimeSpan depatur = new TimeSpan(Convert.ToInt32(Console.ReadLine()), 0, 0);
                                Console.Write("Arrival hours : ");
                                TimeSpan arri = new TimeSpan(Convert.ToInt32(Console.ReadLine()), 0, 0);
                                if (creator.TimeLineCreator(arri, depatur))
                                    Console.WriteLine("Success");
                                else
                                    Console.WriteLine("Error");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Wrong input...");

                            }
                            break;
                        case 4:
                            //Kan altid arbejde på formateringen
                            Console.Clear();
                            List<Airport> airports = api.Airports().ToList();
                            Console.WriteLine("iata  City  Country");
                            for (int i = 0; i < airports.Count(); i++)
                            {
                                Console.WriteLine($"{airports[i].iata} : {airports[i].city} : {airports[i].country} ");
                            }
                            Console.Write("Input iata destination : ");
                            
                            //creator.PlaneCreator()
                            break;
                        default:

                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please input an number...\n");

                }

            }






        }
    }
}
