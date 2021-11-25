using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SmartMeds
{
    class TimeTick
    {
        static event EventHandler minuteTick;
        static bool isTicking = false;
        static Thread countingThread; 
        
        static List<EventHandler> delegates = new List<EventHandler>();

        public static event EventHandler MinuteTick
        {
            add
            {
                minuteTick += value;
                delegates.Add(value);
            }

            remove
            {
                minuteTick -= value;
                delegates.Remove(value);
            }
        }
        public static void Start()
        {
            if (isTicking == false)
            {
                isTicking = true;
                countingThread = new Thread(Update);
                countingThread.Start();
            }
        }
        public static void Stop()
        {
            foreach (EventHandler eh in delegates.ToList())
            {
                MinuteTick -= eh;
            }

            delegates.Clear();
            isTicking = false;
            countingThread.Join();
            countingThread = null;
        }

        static void Update()
        {
            while (isTicking)
            {
                Thread.Sleep(60000);
                minuteTick?.Invoke("", new EventArgs());
            }
        }
    }
}
