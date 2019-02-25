using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Cars
{
    public class CarModel
    {
        public Guid Id { get; set; }

        public string CModel { get; set; }

        public string CManufacture { get; set; }

        public string CModelYear { get; set; }

        public int CMileage { get; set; }

        public string CDescription { get; set; }

        public string CColor { get; set; }

        public int CPrice { get; set; }

        public int CCondition { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CStatus { get; set; }

        public string CVINCode { get; set; }


    }
}
