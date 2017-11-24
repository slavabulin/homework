using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Develop a Countdown class, which implements the capability after the appointed time (waiting time is provided by the user) to transmit
    /// a message to any subscriber who subscribes to the event. You can use the Thread.Sleep method to create a wait effect. Provide the possibility 
    /// of subscribing to an event in several classes. Use the console application for testing.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var countdown = new Countdown(3000);
            var eventReceiver = new EventReceiver();
            var anotherReceiver = new AnotherOneEventReceiver();

            countdown.OnCountdown += eventReceiver.RaiseOnEvent;
            countdown.OnCountdown += anotherReceiver.RaiseOnEventToo;

            countdown.CreateEvent();
            Console.ReadLine();
        }
    }

    public delegate void CountdownEventHandler(object source, CountdownEventArgs e);
    
    public class Countdown
    {
        int _timeToSleep;
        public int TimeToSleep
        {
            get
            {
                return _timeToSleep;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("argument should be more than zero", nameof(value));
                _timeToSleep = value;
            }
        }
        public event CountdownEventHandler OnCountdown;
        public Countdown(int timeToSleep)
        {
            this.TimeToSleep = timeToSleep;
        }
        public void CreateEvent()
        {
            Thread.Sleep(_timeToSleep);
            OnCountdown(this, new CountdownEventArgs("Countdown raised event"));
        }
    }

    public class CountdownEventArgs : EventArgs
    {
        private string EventInfo;
        public CountdownEventArgs(string Text)
        {
            EventInfo = Text;
        }
        public string GetInfo()
        {
            return EventInfo;
        }
    }

    public class EventReceiver
    {
        public void RaiseOnEvent(object source, EventArgs e)
        {
            Console.WriteLine("I've got an event!!!");
        }
    }

    public class AnotherOneEventReceiver
    {
        public void RaiseOnEventToo(object source, EventArgs e)
        {
            Console.WriteLine("God damn,I've got an event too!!!");
        }
    }
}
