using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etat_civile
{
    class Trace
    {
        public string User = Form1.IDUser;
        public string TimeEntrer = Form1.timeEntre;
        public string TimeSortie;
        public string Evenement;
        public string Details = "";
        public string Date = DateTime.Now.ToString();

        public Trace() { }
        public Trace(string TimeEntrer, string TimeSortie, string Evenement, string Details)
        {
            this.TimeEntrer = TimeEntrer;
            this.TimeSortie = TimeSortie;
            this.Evenement = Evenement;
            this.Details = Details;
        }
        public Trace(string events, string details)
        {
            this.Evenement = events;
            this.Details = details;
        }
    }
}
