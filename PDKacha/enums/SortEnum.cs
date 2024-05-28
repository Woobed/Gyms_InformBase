using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDKacha.enums
{
    public enum SortEnum
    {
        [Description("По уменьшению рейтинга")]
        RatingDecrease,
        [Description("По увеличению рейтинга")]
        RatingIncrease,
        [Description("По уменьшению расстояния")]
        DistanceDecreace,
        [Description("По увеличению расстояния")]
        DistanceIncreace,
    }
}
