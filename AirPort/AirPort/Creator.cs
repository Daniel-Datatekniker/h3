using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    class Creator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private AirportData Data = new AirportData();
   
        //Adds data to airport. if primary key already exsist return false
        public bool AirportCreator(string iata, string city, string country)
        {
            if (Data.Airports.Any(o => o.iata == iata.ToUpper()))
                return false;
            else
            {
                Data.Airports.Add(new Airport(iata.ToUpper(), city, country));
                Data.SaveChanges();
                return true;
            }


        }


        //Create an plane, put destination, wanted to change timeline, so it was on the plane object instead. times up now :/
        public bool PlaneCreator(string AirlineName, int DestinationID, int timelineId)
        {
            Plane plane = new Plane();
            plane.airline = AirlineName;
            plane.destination = DestinationID;
            plane.timeline = timelineId;

            try
            {
                Data.Planes.Add(plane);

                var returnValue = Data.SaveChanges();

                if (returnValue > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {


                return false;
            }

        }

        //Wanted to delete this and put it on the plane directly
        public bool TimeLineCreator(TimeSpan arrival, TimeSpan depature)
        {
            Timeline timeline = new Timeline(arrival, depature);

            try
            {
                Data.Timelines.Add(timeline);
                var res = Data.SaveChanges();
                if (res > 0)
                    return true;
                else
                    return false;



            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //Creates the destination and compine it with an existing airport
        public bool DestinationCreator(string airport, int gate)
        {
            Destination destination = new Destination(airport, gate);

            try
            {
                Data.Destinations.Add(destination);
                var res = Data.SaveChanges();
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        //Creates an airline
        public bool AirlineCreator(string AirlineName)
        {
            Airline airline = new Airline();
            airline.name = AirlineName;
            try
            {
                Data.Airlines.Add(airline);

                var returnValue = Data.SaveChanges();

                if (returnValue > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

    }
}
