using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OIdToCode.Core;

namespace OdeToCode.Data
{
    public class SqlRestaurantData: IRestaurantData
    {
        private readonly OdeToCodeDbContext _dbContext;

        public SqlRestaurantData(OdeToCodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Restaurant> GetAll() => _dbContext.Restaurants;

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)=> from r in _dbContext.Restaurants
            where string.IsNullOrEmpty(name) || r.Name.Contains(name)
            orderby r.Name
            select r;

        public Restaurant GetRestaurantById(int Id) => _dbContext.Restaurants.Find(Id);

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _dbContext.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = GetRestaurantById(Id);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountofRestaurants() => _dbContext.Restaurants.Count();

        public int Commit() => _dbContext.SaveChanges();
    }
}