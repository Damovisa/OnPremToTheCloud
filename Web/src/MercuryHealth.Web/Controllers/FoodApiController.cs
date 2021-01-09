﻿using MercuryHealth.Models;
using MercuryHealth.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercuryHealth.Web.Api
{

    public class FoodApiController : Controller
    {
        private IFoodLogEntryRepository repository;

        public FoodApiController(IFoodLogEntryRepository repo)
        {
            this.repository = repo;
        }

        public FoodApiController() : this(new FoodLogEntrySqlRepository())
        {

        }

        // GET: FoodApi
        [HttpPost]
        public bool LogFood(FoodLogEntry food)
        {
            food.MealTime = DateTime.Now;
            this.repository.Create(food);
            return true;
        }

        public bool TriggerFoodLogic()
        {
            var burger = new FoodLogEntry
            {
                Description = "Hamburger",
                Quantity = 1,
                MealTime = DateTime.Now,
                Tags = "heavy, meat",
                Calories = 295,
                ProteinInGrams = 15.96M,
                FatInGrams = 14.15M,
                CarbohydratesInGrams = 26.53M,
                SodiumInGrams = 616.0M,


            };

            return LogFood(burger);
        }
    }
}