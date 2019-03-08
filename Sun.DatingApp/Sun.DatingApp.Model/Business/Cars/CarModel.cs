using System;

namespace Sun.DatingApp.Model.Business.Cars
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
