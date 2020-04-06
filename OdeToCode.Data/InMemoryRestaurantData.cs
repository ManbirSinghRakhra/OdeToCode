using System.Collections.Generic;
using System.Linq;
using OIdToCode.Core;

namespace OdeToCode.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData() =>
            _restaurants = new List<Restaurant>()
            {
                new Restaurant
                    {Id = 1, Name = "Manbir's Pizza", Cuisine = CuisineType.Indian, Location = "Edson, Alberta"},
                new Restaurant
                    {Id = 2, Name = "Kabir's Pizza", Cuisine = CuisineType.Italian, Location = "Edson, Alberta"}
            };

        public IEnumerable<Restaurant> GetAll() => from r in _restaurants orderby r.Name select r;
    }
}