using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace U3_2_Automobiliu_parkas
{
    /// <summary>
    /// Abstract class to describe the data of transport
    /// </summary>
    internal abstract class Transport : IComparable<Transport>, IEquatable<Transport>
    {
        /// <summary>
        /// The license plate number
        /// </summary>
        public string licensePlate { get; private set; }

        /// <summary>
        /// The manufacturers name
        /// </summary>
        public string manufacturer { get; private set; }

        /// <summary>
        /// The transportation vehicle name
        /// </summary>
        public string model { get; private set; }

        /// <summary>
        /// The year and the month of manufacture
        /// </summary>
        public DateTime yearAndMonthOfManufacture { get; private set; }

        /// <summary>
        /// The date until the technical inspection is valid
        /// </summary>
        public DateTime technicalInspectionDuration { get; private set; }

        /// <summary>
        /// The gas type of the vehicle
        /// </summary>
        public string gasType { get; private set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Transport()
        {
            licensePlate = "";
            manufacturer = "";
            model = "";
            yearAndMonthOfManufacture = DateTime.Now;
            technicalInspectionDuration = DateTime.Now;
            gasType = "";
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
        public Transport(string licensePlate, string manufacturer, string model, 
            DateTime yearAndMonthOfManufacture, DateTime technicalInspectionDuration, 
            string gasType)
        {
            this.licensePlate = licensePlate;
            this.manufacturer = manufacturer;
            this.model = model;
            this.yearAndMonthOfManufacture = yearAndMonthOfManufacture;
            this.technicalInspectionDuration = technicalInspectionDuration;
            this.gasType = gasType;
        }

        /// <summary>
        /// Contructor, calling the polymorphism method
        /// </summary>
        /// <param name="data">a line of data</param>
        public Transport(string data)
        {
            SetData(data);
        }

        /// <summary>
        /// Virtual method, which sets the class properties
        /// </summary>
        /// <param name="line">a line of data</param>
        public virtual void SetData(string line)
        {
            string[] parts;
            parts = line.Split(';');
            char type = char.Parse(parts[0]);
            licensePlate = parts[1];
            manufacturer = parts[2];
            model = parts[3];
            yearAndMonthOfManufacture = DateTime.Parse(parts[4]);
            technicalInspectionDuration = DateTime.Parse(parts[5]);
            gasType = parts[6];
        }

        /// <summary>
        /// Overriden Object class method
        /// </summary>
        /// <returns>concatenated string (all class properties)</returns>
        public override string ToString()
        {
            return string.Format("|{0,9}   |{1,-12}    |{2,-7}  |{3,12}      |{4, 10}  | {5, 12}   |",
            licensePlate, manufacturer, model, yearAndMonthOfManufacture.ToString("yyyy/MM"), technicalInspectionDuration.ToString("d"), gasType);
        }

        /// <summary>
        /// Abstract method
        /// </summary>
        /// <param name="transportation">Transport class object</param>
        /// <param name="gasType">the provided gas type</param>
        /// <returns>true or false</returns>
        public abstract bool Suitable(Transport transportation, string gasType);

        /// <summary>
        /// Overriden object class method
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var transport = obj as Transport;
            return Equals(transport);
        }

        /// <summary>
        /// A method to see if class properties are equal
        /// </summary>
        /// <param name="transport">transport class object</param>
        /// <returns>true or false</returns>
        public bool Equals(Transport transport)
        {
            return transport != null &&
                   licensePlate == transport.licensePlate &&
                   manufacturer == transport.manufacturer &&
                   model == transport.model &&
                   yearAndMonthOfManufacture == transport.yearAndMonthOfManufacture &&
                   technicalInspectionDuration == transport.technicalInspectionDuration &&
                   gasType == transport.gasType;
        }

        /// <summary>
        /// Virtual comparison method which compares by the manufacturer and the license plate
        /// </summary>
        /// <param name="diff">differet object</param>
        /// <returns>0, 1 or -1</returns>
        public virtual int CompareTo(Transport diff)
        {
            if ((object)diff == null)
                return 1;

            int result = this.manufacturer.CompareTo(diff.manufacturer);

            if (result == 0)
            {
                return this.licensePlate.CompareTo(diff.licensePlate);
            }
            return result;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            int hashCode = -128836797;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(licensePlate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(model);
            hashCode = hashCode * -1521134295 + yearAndMonthOfManufacture.GetHashCode();
            hashCode = hashCode * -1521134295 + technicalInspectionDuration.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(gasType);
            return hashCode;
        }
    }
}
