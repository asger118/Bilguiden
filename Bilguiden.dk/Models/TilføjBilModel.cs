using System;
using System.Collections.Generic;

namespace Bilguiden.dk.Models {
    public class TilføjBilModel {

        public int Bil_ID { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public Nullable<int> Årgang { get; set; }
        public Nullable<int> Nypris { get; set; }
        public string Gearkasse { get; set; }
        public string Træk { get; set; }
        public Nullable<int> Lastevne { get; set; }
        public Nullable<int> Vægt { get; set; }
        public Nullable<int> Acceleration { get; set; }
        public Nullable<int> Hestekræfter { get; set; }
        public Nullable<int> Newtonmeter { get; set; }
        public string Motor { get; set; }
        public string Drivmiddel { get; set; }
        public Nullable<int> Kubik { get; set; }

    }
}