using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_2_Automobiliu_parkas
{
    /// <summary>
    /// Derived class to describe the data of a lorry
    /// </summary>
    internal class Lorry : Transport, IEquatable<Transport>, IComparable<Transport>
    {
        /// <summary>
        /// The capacity of the vehicles trailer
        /// </summary>
        public double trailerCapacity { get; private set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Lorry() : base()
        {
            trailerCapacity = 0;
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
        /// <param name="trailerCapacity">trailer capacity</param>
        public Lorry(string licensePlate, string manufacturer, string model, 
            DateTime yearAndMonthOfManufacture, DateTime technicalInspectionDuration, 
            string gasType, double trailerCapacity) : base(licensePlate, manufacturer, 
                model, yearAndMonthOfManufacture, technicalInspectionDuration, gasType)
        {
            this.trailerCapacity = trailerCapacity;
        }

        /// <summary>
        /// Abstract method realisation, checks if the transport vehicle is suitable
        /// </summary>
        /// <param name="transportation">transport class object</param>
        /// <param name="gasType">provided gas type</param>
        /// <returns>true or false</returns>
        public override bool Suitable(Transport transportation, string gasType)
        {
            Lorry lorry = transportation as Lorry;

            if (lorry.gasType.Trim() == gasType)
                return true;

            return false;
        }

        /// <summary>
        /// Constructor, calling polymorphism method
        /// </summary>
        /// <param name="data">a line with data</param>
        public Lorry(string data) : base(data)
        {
            SetData(data);
        }

        /// <summary>
        /// Sets the trailer capacity
        /// </summary>
        /// <param name="line">a line with data</param>
        public override void SetData(string line)
        {
            base.SetData(line);
            string[] parts = line.Split(';');
            trailerCapacity = double.Parse(parts[7]);
        }

        /// <summary>
        /// Overriden polymorphism method
        /// </summary>
        /// <param name="diff">different object</param>
        /// <returns>1, 0 or -1</returns>
        public override int CompareTo(Transport diff)
        {
            Lorry lorry = diff as Lorry;

            if (lorry is null)
                return 1;

            if (!(diff is Bus))
                return 1;

            int result = this.manufacturer.CompareTo(lorry.manufacturer);

            if (result == 0)
            {
                return this.licensePlate.CompareTo(lorry.licensePlate);
            }
            return result;
        }

        /// <summary>
        /// Overriden Object class method
        /// </summary>
        /// <returns>concatenated string (all class properties)</returns>
        public override string ToString()
        {
            return String.Format("| {0,10}       {1}          |           |  {2,10:f2}     |", GetType().Name,
                                  base.ToString(), trailerCapacity);
        }
    }
}