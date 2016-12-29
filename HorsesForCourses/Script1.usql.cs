using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HorsesForCourses
{
    // http://www.slideshare.net/MichaelRys/usql-userdefined-operators-udos-sqlbits-2016
    public class LastTwentyRacesCount : IAggregate<DateTime, string, bool>
    {
        private SortedDictionary<DateTime, string> _lastTwenties;

        public override void Init()
        {
            _lastTwenties = new SortedDictionary<DateTime, string>();
        }

        public override void Accumulate(DateTime collectedAt, string lastTwenty)
        {
            _lastTwenties.Add(collectedAt, lastTwenty);
        }

        public override bool Terminate()
        {
            var values = _lastTwenties.Values.ToList();
            for (var i = 0; i < values.Count - 1; i++)
            {
                if (!values[i + 1].StartsWith(values[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
