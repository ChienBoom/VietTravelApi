using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VietTravelApi.Context;
using VietTravelApi.Models;

namespace VietTravelApi.Common
{
    public class DeleteModels
    {
        public DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public DeleteModels(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        public void DeleteCity(long id)
        {
            List<Tour> tours = _dataContext.Tour.Where(o => o.CityId == id).ToList();
            List<Evaluate> evaluates = _dataContext.Evaluate.Where(o => o.Eva == 1 && o.EvaId == id).ToList();
            List<Hotel> hotels = _dataContext.Hotel.Where(o => o.CityId == id).ToList();
            List<Restaurant> restaurants = _dataContext.Restaurant.Where(o => o.CityId == id).ToList();
            List<TourGuide> tourGuides = _dataContext.TourGuide.Where(o => o.CityId == id).ToList();
            if (tours.Count > 0)
            {
                foreach(Tour item in tours)
                {
                    item.IsDelete = 1;
                    DeleteTour(item.Id);
                }
            }
            if(evaluates.Count > 0)
            {
                foreach(Evaluate item in evaluates)
                {
                    item.IsDelete = 1;
                }
            }
            if (hotels.Count > 0)
            {
                foreach (Hotel item in hotels)
                {
                    item.IsDelete = 1;
                    DeleteHotel(item.Id);
                }
            }
            if (restaurants.Count > 0)
            {
                foreach (Restaurant item in restaurants)
                {
                    item.IsDelete = 1;
                    DeleteRestaurant(item.Id);
                }
            }
            if (tourGuides.Count > 0)
            {
                foreach (TourGuide item in tourGuides)
                {
                    item.IsDelete = 1;
                }
            }
        }

        public void DeleteTour(long id)
        {
            List<TourPackage> tourPackages = _dataContext.TourPackage.Where(o => o.TourId == id).ToList();
            List<Evaluate> evaluates = _dataContext.Evaluate.Where(o => o.Eva == 2 && o.EvaId== id).ToList();
            List<Event> events = _dataContext.Event.Where(o => o.TourId == id).ToList();
            List<Schedule> schedules = _dataContext.Schedule.Where(o => o.TourId == id).ToList();
            if (tourPackages.Count > 0)
            {
                foreach (TourPackage item in tourPackages)
                {
                    item.IsDelete = 1;
                }
            }
            if (evaluates.Count > 0)
            {
                foreach (Evaluate item in evaluates)
                {
                    item.IsDelete = 1;
                }
            }
            if (events.Count > 0)
            {
                foreach (Event item in events)
                {
                    item.IsDelete = 1;
                }
            }
            if (schedules.Count > 0)
            {
                foreach (Schedule item in schedules)
                {
                    item.IsDelete = 1;
                }
            }
        }

        public void DeleteHotel(long id)
        {
            List<Evaluate> evaluates = _dataContext.Evaluate.Where(o => o.Eva == 3 && o.EvaId == id).ToList();
            if (evaluates.Count > 0)
            {
                foreach (Evaluate item in evaluates)
                {
                    item.IsDelete = 1;
                }
            }
        }

        public void DeleteRestaurant(long id)
        {
            List<Evaluate> evaluates = _dataContext.Evaluate.Where(o => o.Eva == 4 && o.EvaId == id).ToList();
            if (evaluates.Count > 0)
            {
                foreach (Evaluate item in evaluates)
                {
                    item.IsDelete = 1;
                }
            }
        }

        public void DeleteUser(long id)
        {
            List<Evaluate> evaluates = _dataContext.Evaluate.Where(o => o.UserId == id).ToList();
            if (evaluates.Count > 0)
            {
                foreach (Evaluate item in evaluates)
                {
                    item.IsDelete = 1;
                }
            }
        }

    }
}
