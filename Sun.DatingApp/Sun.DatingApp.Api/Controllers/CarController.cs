using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Cars;
using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Api.Controllers
{
    public class CarController : BaseController
    {
        public CarController()
        {
        }

        [HttpGet("cars")]
        public IActionResult Cars()
        {
            var ipp = @"";

            var models = new List<CarModel>();

            var m1 = new CarModel()
            {
                Id = Guid.NewGuid(),
                CModel = "Passport",
                CManufacture = "Honda",
                CModelYear = "2002",
                CMileage = 3812,
                CDescription = "这是描述",
                CColor = "Puce",
                CPrice = 41299,
                CCondition = 1,
                CreatedDate = DateTime.Now,
                CStatus = 0,
                CVINCode = "WVWEU9AN4AE524071"
            };
            var m2 = new CarModel()
            {
                Id = Guid.NewGuid(),
                CModel = "Passport",
                CManufacture = "Honda",
                CModelYear = "2002",
                CMileage = 3812,
                CDescription = "这是描述",
                CColor = "Puce",
                CPrice = 41299,
                CCondition = 1,
                CreatedDate = DateTime.Now,
                CStatus = 0,
                CVINCode = "WVWEU9AN4AE524071"
            };
            var m3 = new CarModel()
            {
                Id = Guid.NewGuid(),
                CModel = "Passport",
                CManufacture = "Honda",
                CModelYear = "2002",
                CMileage = 3812,
                CDescription = "这是描述",
                CColor = "Puce",
                CPrice = 41299,
                CCondition = 1,
                CreatedDate = DateTime.Now,
                CStatus = 0,
                CVINCode = "WVWEU9AN4AE524071"
            };

            models.Add(m1);
            models.Add(m2);
            models.Add(m3);

            return new JsonResult(models);
        }
    }
}