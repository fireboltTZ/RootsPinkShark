using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;

namespace Utility
{
    public class MyRandom<T> : QFramework.Singleton<MyRandom<T>>
    {
        public List<T> GetDifferentRand(List<T> list, int num)
        {
            List<T> res = new List<T>();
            List<T> clone = new List<T>() { };
            clone.AddRange(list);
            for (int i = 0; i < num; i++)
            {
                int rand = UnityEngine.Random.Range(0, clone.Count);
                res.Add(clone[rand]);
                clone.RemoveAt(rand);
            }

            return res;
        }
    }
}