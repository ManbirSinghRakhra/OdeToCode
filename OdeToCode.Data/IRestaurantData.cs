using System.Collections;
using System.Collections.Generic;
using OIdToCode.Core;

namespace OdeToCode.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}