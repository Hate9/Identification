using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hate9
{
    public static class Identification
    {
        private static List<int> usedIds = new List<int>();

        public static int CreateId()
        {
            int tempId = IntuitiveRNG.realRNG.Next(0, int.MaxValue);
            while (usedIds.Contains(tempId))
            {
                tempId = IntuitiveRNG.realRNG.Next(0, int.MaxValue);
            }
            usedIds.Add(tempId);
            return tempId;
        }

        public static bool IdExists(int id)
        {
            return usedIds.Contains(id);
        }

        public static void DeleteId(int id)
        {
            usedIds.Remove(id);
        }
    }
}
