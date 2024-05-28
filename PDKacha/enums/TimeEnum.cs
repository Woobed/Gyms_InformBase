using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDKacha.enums
{
    public enum TimeEnum
    {
        [Description("Круглосуточно")]
        FullTime,

        [Description("Утро")]
        Morning,

        [Description("Середина дня")]
        MidDay,

        [Description("Вечер")]
        Evening,
    }
}
