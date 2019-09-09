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
        private Random rng;

        public Identification(int seed = -1)
        {
            usedIds = new List<int>();
            if (seed == -1)
            {
                rng = new Random();
            }
            else
            {
                rng = new Random(seed);
            }
        }

        public int CreateId()
        {
            int tempId = rng.Next(0, int.MaxValue);
            while (usedIds.Contains(tempId))
            {
                tempId = rng.Next(0, int.MaxValue);
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
