using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject
{
    internal class Beer : IComparable
    {
        public enum _beerType
        {
            LAGER,
            PILSNER,
            MÜNCHENER,
            WIENERDORTMUNDER,
            BOCK,
            DOBBELBOCK,
            PORTER,
            MIX
        }

        private string _brewery;
        private string _beerName;
        private _beerType _BeerType;
        private double _volume;
        private double _percent;

        public Beer()
        {

        }

        public Beer(string brewery, string beerName, double volume, double percent, _beerType BeerType)
        {
            _brewery = brewery;
            _beerName = beerName;
            _volume = volume;
            _percent = percent;
            _BeerType = BeerType;
        }

        public string BreweryProp
        {
            get { return _brewery; }
            set { _brewery = value; }
        }

        public string BeerNameProp
        {
            get { return _beerName; }
            set { _beerName = value; }
        }
        public _beerType BeerTypeProp
        {
            get { return _BeerType; }
            set { _BeerType = value; }
        }

        public double VolumeProp
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public double PercentProp
        {
            get { return _percent; }
            set { _percent = value; }
        }

        public double GetUnits()
        {
            return VolumeProp * PercentProp / 1.50;
        }

        public override string ToString()
        {
            return String.Format("Brewery:{0,5} Beer Name:{1,5} Beer Type: {2,5} Volume:{3,2} Percent:{4,2} Units:{5,2}", BreweryProp, BeerNameProp, BeerTypeProp, VolumeProp, PercentProp, GetUnits());
        }

        public Beer Add(Beer nB)
        {
            this._volume= this._volume + nB._volume;
            this._percent = this._volume * this._percent + _volume *nB._percent /(this._volume + nB._volume);
            this._brewery = this._brewery + " + " + nB._brewery;
            this._beerName = this._beerName + " + " + nB._beerName;
            this._BeerType = _beerType.MIX;
            Beer b1 = new Beer(this._brewery, this._beerName, this._volume, this._percent, _beerType.MIX);
            return b1;

        }

        public Beer Mix(Beer newBeer)
        {
            double volumeValue = newBeer.VolumeProp + this.VolumeProp;
            double PercentValue = newBeer.VolumeProp * newBeer.PercentProp + this.VolumeProp * this.PercentProp / (this._volume + newBeer.VolumeProp);
            string breweryNameValue = this._brewery + " + " + newBeer._brewery;
            string beerNameValue = this._beerName + " + " + newBeer._beerName;
            return new Beer(breweryNameValue, beerNameValue ,volumeValue, PercentValue, _beerType.MIX);
        }
        public static Beer Mix(Beer b1, Beer b2)
        {
            double volumeValue = b1.VolumeProp + b2.VolumeProp;
            double PercentValue = b1.VolumeProp * b1.PercentProp + b2.VolumeProp *b2.PercentProp / (b1.VolumeProp + b2.VolumeProp);
            string BeerNameValue = b1.BeerNameProp + " + " + b2.BeerNameProp;
            string BreweryNameValue = b1.BreweryProp + " + " + b2.BreweryProp;
            return new Beer(BreweryNameValue, BeerNameValue, volumeValue, PercentValue, _beerType.MIX);
        }

        public int CompareTo(object b1)
        {
            double result = ((Beer)b1).GetUnits() - GetUnits();
            if (result > 0)
                return 1;
            else if (result < 0)
                return -1;
            else
                return 0;
        }
    }
}
