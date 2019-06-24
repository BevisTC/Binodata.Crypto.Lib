using System;
using System.Collections.Generic;
using System.Text;

namespace Binodata.Crypto.Lib.Utility
{
    public class UnixTimeGenerator
    {
        /// <summary>
		/// Get Unix Utc 0 expired total seconds utc time - 1970/1/1 total seconds
		/// </summary>
		/// <param name="addMinutes"></param>
		/// <returns></returns>
		public static long GetExpiredUtc0UnixTime(double addMinutes)
        {

            return (long)(DateTime.UtcNow.AddMinutes(addMinutes).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalSeconds;
        }

        /// <summary>
        /// Get Unix Utc 0 total seconds utc time - 1970/1/1 total seconds
        /// </summary>
        /// <returns></returns>
        public static long GetUtcNowUnixTime()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds;
        }
    }
}
