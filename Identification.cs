using System;
using System.Collections.Generic;

namespace Hate9
{
    public class Identification
    {
        private List<int> usedIds;
        private Random rng;

        /// <summary>A read-only copy of the <see cref="Identification"/>'s id registry, representing the ids currently in use.</summary>
        public List<int> ids => usedIds;

        /// <summary>Initializes a new Identification object.</summary>
        /// <param name="seed">If specified, used as the seed for the internal Random object, which is used to create new ids.</param>
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

        /// <summary>Addes the specified id to the <see cref="Identification"/>'s registry.</summary>
        /// <param name="id">The specified id.</param>
        /// <returns>a <see cref="bool"/> representing the success or failure of the operation.</returns>
        public bool CreateId(int id)
        {
            try
            {
                CreateId((int?)id);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>Creates and returns a new id in the <see cref="Identification"/>'s registry, which can be specified if necessary.</summary>
        /// <param name="id">The specified id.</param>
        /// <returns>the generated id.</returns>
        public int CreateId(int? id = null)
        {
            int tempId;
            if (id != null)
            {
                if (IdExists((int)id))
                {
                    throw new ArgumentException("id is already in use.");
                }
                else
                {
                    usedIds.Add((int)id);
                    return (int)id;
                }
            }
            else
            {
                if (ids.Count == (int.MaxValue + Math.Abs(int.MinValue) + 1))
                {
                    throw new Exception("All possible id values in use.");
                }
                tempId = rng.Next(0, int.MaxValue);
                while (IdExists(tempId))
                {
                    tempId = rng.Next(0, int.MaxValue);
                }
                usedIds.Add(tempId);
                return tempId;
            }
        }

        /// <summary>Checks whether or not the specified id currently exists in the <see cref="Identification"/>'s registry.</summary>
        /// <param name="id">The specified id.</param>
        /// <returns><see cref="true"/> if id is found; otherwise, <see cref="false"/>.</returns>
        public bool IdExists(int id)
        {
            return usedIds.Contains(id);
        }

        /// <summary>Removes the specified id from the <see cref="Identification"/>'s registry.</summary>
        /// <param name="id">The specified id.</param>
        /// <returns><see cref="true"/> if id is successfully removed; otherwise, <see cref="false"/>. This method also returns <see cref="false"/> if the id is not found in the registry.</returns>
        public bool DeleteId(int id)
        {
            return usedIds.Remove(id);
        }
    }
}
