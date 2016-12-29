using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HorsesForCourses
{
    public class LastTwentyStartsAggregate : IAggregate<string, float>
    {
        public override void Init()
        {
        }

        public override void Accumulate(string t1)
        {
        }

        public override float Terminate()
        {
            return 0.0F;
        }
    }
}
