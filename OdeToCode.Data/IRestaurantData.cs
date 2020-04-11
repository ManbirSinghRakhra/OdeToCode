using System.Collections;
using System.Collections.Generic;
using OIdToCode.Core;

namespace OdeToCode.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int Id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant restaurant);
        Restaurant Delete(int Id);
        int Commit();
    }
}