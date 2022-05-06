using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject
{
    internal class SortingBeerBy : IComparer
    {
        public enum _sortBy
        {
            UNIT,
            PERCENT,
            VOLUME
        }
        
        private _sortBy sortBy;
        
        public SortingBeerBy(_sortBy SortBy)
        {
            sortBy = SortBy;
        }
            public int Compare(object b1, object b2)
            {
                double result = ((Beer)b1).GetUnits() - ((Beer)b2).GetUnits();
                if (result > 0)
                    return 1;
                else if (result < 0)
                    return -1;
                else
                    return 0;
            }

        public class CompareByPercent : IComparer
        {
            public int Compare(object b1, object b2)
            {
                double result = ((Beer)b1).PercentProp - ((Beer)b2).PercentProp;
                if (result > 0)
                    return 1;
                else if (result < 0)
                    return -1;
                else
                    return 0;
            }
        }

        public class CompareByVolume : IComparer
        {
            public int Compare(object b1, object b2)
            {
                double result = ((Beer)b1).VolumeProp - ((Beer)b2).VolumeProp;
                if (result > 0)
                    return 1;
                else if (result < 0)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
