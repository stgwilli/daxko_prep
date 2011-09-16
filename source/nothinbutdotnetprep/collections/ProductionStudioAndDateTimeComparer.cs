using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ProductionStudioAndDateTimeComparer : IComparer<Tuple<ProductionStudio, DateTime>>
    {
        readonly IDictionary<ProductionStudio, int> studio_rankings = new Dictionary<ProductionStudio, int>
            {
                { ProductionStudio.Disney, 4},
                { ProductionStudio.Universal, 3},
                { ProductionStudio.Dreamworks, 2},
                { ProductionStudio.Pixar, 1},
                { ProductionStudio.MGM, 0}
            };

        public int Compare(ProductionStudio x, ProductionStudio y)
        {
            return studio_rankings[x].CompareTo(studio_rankings[y]);
        }

        public int Compare(Tuple<ProductionStudio, DateTime> x, Tuple<ProductionStudio, DateTime> y)
        {
            return studio_rankings[x.Item1].CompareTo(studio_rankings[y.Item1]) == 0 
                ? x.Item2.Year.CompareTo(y.Item2.Year) 
                : studio_rankings[x.Item1].CompareTo(studio_rankings[y.Item1]);
        }
    }
}