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
        public List<int> ids => usedIds;
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

        public int CreateId(int id = -1)
        {
            int tempId;
            if (id != -1)
            {
                if (IdExists(id))
                {
                    return -1;
                }
                else
                {
                    usedIds.Add(id);
                    return id;
                }
            }
            else
            {
                tempId = rng.Next(0, int.MaxValue);
                while (IdExists(tempId))
                {
                    tempId = rng.Next(0, int.MaxValue);
                }
                usedIds.Add(tempId);
                return tempId;
            }
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
