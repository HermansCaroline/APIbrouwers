using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BrouwersClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //DATA WIJZIGEN MET EEN PUT REQUEST
            Console.WriteLine("WIJZIGEN");
            Console.Write("Tik een id: ");
            var id = int.Parse(Console.ReadLine());
            var client = new HttpClient();
            var url = "http://localhost:11171/brewers/" + id;
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var brouwer = response.Content.ReadAsAsync<Brouwer>().Result;
                brouwer.Gemeente = brouwer.Gemeente.ToUpper();
                response = client.PutAsJsonAsync<Brouwer>(url, brouwer).Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Er is een fout opgetreden: " + response.StatusCode);
                }
            }

            //DATA TOEVOEGEN MET EEN POST REQUEST
            //var brouwer = new Brouwer();
            //Console.Write("Naam: ");
            //brouwer.Naam = Console.ReadLine();
            //Console.Write("Postcode: ");
            //brouwer.Postcode = int.Parse(Console.ReadLine());
            //Console.Write("Gemeente: ");
            //brouwer.Gemeente = Console.ReadLine();
            //var client = new HttpClient();
            //var response = client.PostAsJsonAsync<Brouwer>("http://localhost:11171/brewers/", brouwer).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine("Url nieuwe brouwer: " + response.Headers.Location);
            //}
            //else
            //{
            //    Console.WriteLine("Probleem bij toevoegen brouwer: " + response.StatusCode);
            //}

            //DATA VERWIJDEREN MET EEN DELETE REQUEST
            //const string serviceURI = "http://localhost:11171/brewers";
            //Console.Write("Tik een id: ");
            //var id = int.Parse(Console.ReadLine());
            //var client = new HttpClient();
            //var response = client.DeleteAsync(serviceURI + "/" + id).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    response = client.GetAsync(serviceURI).Result;
            //    var brouwers = response.Content.ReadAsAsync<Brouwers>().Result;
            //    brouwers.ForEach(beknopt => Console.WriteLine(beknopt.ID + ":" + beknopt.Naam));
            //}
            //else
            //{
            //    Console.WriteLine("Kan brouwer niet verwijderen");
            //}

            //DATA LEZEN MET GET REQUESTS
            Console.WriteLine("LEZEN");
            client = new HttpClient();
            response = client.GetAsync("http://localhost:11171/brewers").Result;
            if (response.IsSuccessStatusCode)
            {
                var brouwers = response.Content.ReadAsAsync<Brouwers>().Result;
                brouwers.ForEach(beknopt => Console.WriteLine(beknopt.ID + ":" + beknopt.Naam));
                Console.Write("Kies een id: ");
                id = int.Parse(Console.ReadLine());
                foreach (var brouwerBeknopt in brouwers)
                {
                    if (brouwerBeknopt.ID == id)
                    {
                        response = client.GetAsync(brouwerBeknopt.Detail).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var brouwer = response.Content.ReadAsAsync<Brouwer>().Result;
                            Console.WriteLine(brouwer.Postcode + " " + brouwer.Gemeente);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Brouwer niet meer gevonden");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Brouwers niet gevonden");
            }
        }
    }
}
