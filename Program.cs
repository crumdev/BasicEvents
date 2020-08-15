using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEventsCore
{
    // define the delegate for the event handler
    public delegate void myEventHandler(string value);


    class Program
    {
        static void Main(string[] args)
        {
            // use a named function as an event handler
            EventPublisher obj = new EventPublisher();
            obj.valueChanged += obj_valueChanged;
            obj.valueChanged += obj_parseValue;

            string str;
            do {
                Console.WriteLine("\nEnter a value: ");
                str = Console.ReadLine();
                if (!str.Equals("exit")) {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");
        }
        static void obj_valueChanged(string value)
        {
            Console.WriteLine("\nThe value changed to '{0}'", value);
        }

        static void obj_parseValue(string value)
        {
            if(int.TryParse(value, out int result))
            {
                Console.WriteLine($"Value {value} * 2 = {result*2}");
            }
            else
            {
                Console.WriteLine($"'{value}' is not a number");
            }
        }
    }
    class EventPublisher
    {
        private string theVal;

        // declare the event
        public event myEventHandler valueChanged;

        public string Val
        {
            set
            {
                this.theVal = value;
                // when the value changes, fire the event
                this.valueChanged(theVal);
            }
        }
    }
}
