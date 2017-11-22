using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	/// <summary>
	/// Customer class has three public properties - Name (string), ContactPhone (string) and Revenue (decimal). 
	/// Implement for the Customer's objects the capability of a various string representation. For example, 
	/// the object with the Name = "Jeffrey Richter", Revenue = 1000000, ContactPhone = "+1 (425) 555-0100"
	/// can have the following string representation:	
	/// Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100 
	/// Customer record: +1 (425) 555-0100 
	/// Customer record: Jeffrey Richter, 1,000,000.00 
	/// Customer record: Jeffrey Richter 
	/// Customer record: 1000000, etc.
	/// Add to Customer class an additional formatting capability, that is not provided by the class (Customer class do
	/// not change). Develop unit tests. 
	/// /// </summary>
	class Task1
    {
        static void Main(string[] args)
        {
        }
    }

    public class Customer:IFormattable
    {
		string _name, _contactPhone;
		double _revenue;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (!String.IsNullOrEmpty(value))
					this._name = value;
			}
		}
        public double Revenue
		{
			get
			{
				return _revenue;
			}
			set
			{
				if (!Double.IsNaN(value)
					||!Double.IsNegativeInfinity(value)
					||!Double.IsPositiveInfinity(value)
					||!Double.IsInfinity(value)
					)
					this._revenue = value;
			}
		}
		public string ContactPhone
		{
			get
			{
				return _contactPhone;
			}
			set
			{
				if (!String.IsNullOrEmpty(value))
					this._contactPhone = value;
			}
		}

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider != null)
            {
                ICustomFormatter formatter = formatProvider.GetFormat(this.GetType()) as ICustomFormatter;
                if (formatter != null) return formatter.Format(format, this, formatProvider);
            }
            if (format == null) format = "\0";
            var sb = new StringBuilder();
            sb.Append("Customer record: ");
            foreach(char c in format)
            {
                switch (c)
                {
                    case 'N':
                        sb.Append(this.Name);
                        sb.Append(" ");
                        break;
                    case 'R':
                        sb.Append(this.Revenue.ToString());
                        sb.Append(" ");
                        break;
                    case 'P':
                        sb.Append(this.ContactPhone);
                        sb.Append(" ");
                        break;
                    default:
                        sb.Append(this.Name);
                        sb.Append(" ");
                        sb.Append(this.Revenue.ToString());
                        sb.Append(" ");
                        sb.Append(this.ContactPhone);
                        break;
                }
            }
            
            return sb.ToString();
        }
    }

    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            switch (format)
            {
                default: return arg.ToString();
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return CultureInfo.CurrentCulture.
                        GetFormat(formatType);
            }
        }
    } 
}


/*public class Customer : IFormattable
    {
        public Customer(string name, decimal revenue, string contactPhone)
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = contactPhone;
        }

        public string Name { get; set; }

        public decimal Revenue { get; set; }

        public string ContactPhone { get; set; }

        /// <summary>
        ///     Returns formated string representing customer
        ///     r - revenue
        ///     p - phone
        ///     n - name
        ///     Combos are accepted
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns>Formated string</returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider != null)
            {
                var fmt = formatProvider.GetFormat(
                        GetType())
                    as ICustomFormatter;
                if (fmt != null)
                    return fmt.Format(format, this, formatProvider);
            }
            var ret = new StringBuilder();
            for (var i = 0; i < format.Length; i++)
            {
                if (i != 0)
                    ret.Append(" ");

                switch (format[i])
                {
                    case 'n':
                        ret.Append($"{Name}");
                        break;
                    case 'p':
                        ret.Append($"{ContactPhone}");
                        break;
                    case 'r':
                        ret.Append(Revenue.ToString("N2"));
                        break;
                    case 'G':
                        ret.Append($"{Name}");
                        break;
                    default:
                        ret.Append($"{Name}");
                        break;
                }

                if (i + 1 < format.Length)
                    ret.Append(",");
            }
            return ret.ToString();
        }
    }*/
