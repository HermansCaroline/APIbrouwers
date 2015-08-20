using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrouwersService.Models
{
    public class InMemoryDataBase
    {
        private static Dictionary<int, Brouwer> brouwersValue;
        static InMemoryDataBase()
        {
            var achouffe = new Brouwer { ID = 1, Naam = "Achouffe", Postcode = 6666, Gemeente = "Achouffe" };
            var alken = new Brouwer { ID = 2, Naam = "Alken", Postcode = 3570, Gemeente = "Alken" };
            var bavik = new Brouwer { ID = 3, Naam = "Bavik", Postcode = 8531, Gemeente = "Bavikhove" };
            brouwersValue = new Dictionary<int, Brouwer> { 
            { achouffe.ID, achouffe }, { alken.ID, alken }, { bavik.ID, bavik } 
            };
        }
        public static Dictionary<int, Brouwer> Brouwers
        {
            get { return brouwersValue; }
        }
    }
}