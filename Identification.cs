using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hate9
{
    public class Identification
    {
        private List<int> usedIds;

        public Identification()
        {
            usedIds = new List<int>();
        }

        public int CreateId()
        {
            int tempId = IntuitiveRNG.realRNG.Next(0, int.MaxValue);
            while (usedIds.Contains(tempId))
            {
                tempId = IntuitiveRNG.realRNG.Next(0, int.MaxValue);
            }
            usedIds.Add(tempId);
            return tempId;
        }

        public bool IdExists(int id)
        {
            return usedIds.Contains(id);
        }

        public void DeleteId(int id)
        {
            usedIds.Remove(id);
        }
    }
}
