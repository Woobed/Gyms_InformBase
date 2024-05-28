using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDKacha.Interfaces
{
    public abstract class _GymArray
    {
        public string gymName { get; set; }
        public string orgName { get; set; }
        public string trainingType { get; set; }

        public List<string> imageURL;

        public string phoneNumber { get; set; }
        public string phoneNumberRes { get; set; }
        public string webLinc { get; set; }
        public string workingStartTime { get; set; }
        public string workingEndTime { get; set; }
        public string address { get; set; }

        public string price { get; set; }
        public string rating { get; set; }
    }
}
