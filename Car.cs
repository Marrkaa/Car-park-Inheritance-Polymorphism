using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace U3_2_Automobiliu_parkas
{
    /// <summary>
    /// Derived class to describe the data of a car
    /// </summary>
    internal class Car : Transport, IEquatable<Transport>, IComparable<Transport>
    {
        /// <summary>
        /// The door count
        /// </summary>
        public int doorCount { get; private set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Car() : base()
        {
            doorCount = 0;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="licensePlate">license plate of transport</param>
        /// <param name="manufacturer">manufacturing company name</param>
        /// <param name="model">the model</param>
        /// <param name="yearAndMonthOfManufacture">the year and the month of manufacture</param>
        /// <param name="technicalInspectionDuration">technical inspection date</param>
        /// <param name="gasType">gas type</param>
        /// <param name="doorCount">door count</param>
        public Car(string licensePlate, string manufacturer, string model, 
            DateTime yearAndMonthOfManufacture, DateTime technicalInspectionDuration, 
            string gasType, int doorCount) : base(licensePlate, manufacturer, model, 
                yearAndMonthOfManufacture, technicalInspectionDuration, gasType)
        {
            this.doorCount = doorCount;
        }

        /// <summary>
        /// Abstract method realisation, checks if the transport vehicle is suitable
        /// </summary>
        /// <param name="transportation">transport class object</param>
        /// <param name="gasType">provided gas type</param>
        /// <returns>true or false</returns>
        public override bool Suitable(Transport transportation, string gasType) 
        {
            Car car = transportation as Car;

            if (car.gasType.Trim() == gasType)
                return true;

            return false;
        }

        /// <summary>
        /// Constructor, calling polymorphism method
        /// </summary>
        /// <param name="data">a line with data</param>
        public Car(string data) : base(data)
        {
            SetData(data);
        }

        /// <summary>
        /// Sets the door count
        /// </summary>
        /// <param name="line">a line with data</param>
        public override void SetData(string line) 
        {
            base.SetData(line);
            string[] parts = line.Split(';');
            doorCount = int.Parse(parts[7]);
        }

        /// <summary>
        /// Overriden polymorphism method
        /// </summary>
        /// <param name="diff">different object</param>
        /// <returns>1, 0 or -1</returns>
        public override int CompareTo(Transport diff)
        {
            Car car = diff as Car;

            if (car is null)
                return 1;

            if (!(diff is Car))
                return 1;

            int result = this.manufacturer.CompareTo(car.manufacturer);

            if (result == 0)
            {
                return this.licensePlate.CompareTo(car.licensePlate);
            }
            return result;
        }

        /// <summary>
        /// Overriden Object class method
        /// </summary>
        /// <returns>concatenated string (all class properties)</returns>
        public override string ToString() 
        {
            return String.Format("| {0,10}       {1} {2,4}     |           |                 |", GetType().Name,
                                  base.ToString(), doorCount);
        }
    }
}
