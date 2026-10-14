using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        private double jelenlegiHomerseklet;
        private double celHomerseklet;
        public double JelenlegiHomerseklet
        {
            get
            {
                return this.jelenlegiHomerseklet;
            }
            private set
            {
                this.jelenlegiHomerseklet = value;
            }
        }

        public double CelHomerseklet
        {
            get
            {
                return this.celHomerseklet;
            }
            private set
            {
                this.celHomerseklet = value;
            }
        }
        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string[] reszek = parancs.Split(':');
                this.CelHomerseklet = double.Parse(reszek[1]);
                this.UtolsoFrissites = DateTime.Now;
            }
        }

        public override string AllapotJelentes()
        {
            return $"{this.Nev}: jelenlegi hőmérséklet: {this.JelenlegiHomerseklet} °C, célhőmérséklet: {this.CelHomerseklet} °C.";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0;
        }
    }
}