using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Generic.Dictionary<int, object>;
namespace Presentation.Utils
{
    public static class Utils
    {
        /// <summary>
        /// Method returns the status code  description ntered in the bll responses.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetCode(this KeyCollection key)
        {
            int value = 0;
            foreach (var item in key)
            {
                if (int.TryParse(item.ToString(), out value))
                    break;
            }

            return value;
        }
        /// <summary>
        /// Method returns the first value entered in the bll responses.
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static object GetFirstValue(this ValueCollection Values)
        {
            foreach (var item in Values)
            {
                return item;
            }
            return null;
        }
    }
}
