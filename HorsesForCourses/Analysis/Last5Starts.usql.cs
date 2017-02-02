using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HorsesForCourses
{
    public class Udfs
    {
        public static double AverageLastFiveStarts(string lastFiveStarts, double? avgPosition, double? avgPositionAbove9)
        {
            var paddedLastFiveStarts = lastFiveStarts.PadLeft(5, 'x');
            var vector = paddedLastFiveStarts
                .Select(c =>
                {
                    switch (c)
                    {
                        case 'x':
                        case 'f':
                            return avgPosition.Value;
                        case '0':
                            return avgPositionAbove9.Value;
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            return ((float) c) - 48;
                        default:
                            throw new ArgumentOutOfRangeException("lastFiveStarts", lastFiveStarts, "Invalid character in last five starts");
                    }
                });
            return vector.Average();
        }
    }
}
