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

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) => from r in _restaurants
            where string.IsNullOrEmpty(name) || r.Name.Contains(name)
            orderby r.Name
            select r;

        public Restaurant GetRestaurantById(int Id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == Id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(c => c.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = _restaurants.SingleOrDefault(c => c.Id == Id);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}