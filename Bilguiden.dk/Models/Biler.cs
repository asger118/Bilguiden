//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bilguiden.dk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Biler
    {
        public int Bil_ID { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public Nullable<int> Årgang { get; set; }
        public Nullable<int> Nypris { get; set; }
        public string Gearkasse { get; set; }
        public string Træk { get; set; }
        public Nullable<int> Lastevne { get; set; }
        public Nullable<int> Vægt { get; set; }
        public Nullable<decimal> Acceleration { get; set; }
        public Nullable<int> Hestekræfter { get; set; }
        public Nullable<int> Newtonmeter { get; set; }
        public string Motor { get; set; }
        public string Drivmiddel { get; set; }
        public Nullable<int> Kubik { get; set; }
        public byte[] Billede { get; set; }
    }

    public enum Gearkasse {
        Automatisk, Manuel
    }

    public enum Drivmiddel {
        Benzin, Diesel, El, Hybrid
    }

    public enum Træk {
        FWD, RWD, AWD
    }
}
