using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    class Api
    {
        //Wanted to retrieve data here and join them together.
        AirportData data = new AirportData();

        public IEnumerable<Airport> Airports()
        {
            return data.Airports;
        }

        public IEnumerable<Destination> destinations(string iata)
        {
            //borrowed from here https://entityframework.net/joining But doesnt work, 
            //using (var context = new AirportData())
            //{
            //    var data = context.Destinations
            //        .Join(
            //            context.Airports,
            //            des => des.airport,
            //            port => port.??????,  // ??? cant find anything inside my "book"
            //            (des, port) => new
            //            {
            //                destinati = book.BookId,
            //                AuthorName = author.Name,
            //                BookTitle = book.Title
            //            }
            //        ).ToList();

            //    foreach (var book in data)
            //    {
            //        Console.WriteLine("Book Title: {0} \n\t Written by {1}", book.BookTitle, book.AuthorName);
            //    }
            //}
            //foreach (var item in des)
            //{

            //}
            return false;
        }
    }
}
