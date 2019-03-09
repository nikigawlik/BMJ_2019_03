using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

namespace NilsGameUtils
{
    public static class Utils {
        public delegate float WeightFunction<T>(T obj); 

        /// Chooses a thing from an IEnumerable (Array, List) using weighted randomness
        public static T Choose<T>(IEnumerable<T> spawnOptions, WeightFunction<T> WeightOf, System.Random systemRandom = null) {
            float weightSum = 0;
            foreach (T t in spawnOptions)
            {
                weightSum += WeightOf(t);
            }

            if(weightSum == 0) {
                return default(T);
            }

            float choice;
            if(systemRandom != null) {
                choice = (float)systemRandom.NextDouble() * weightSum;
            } else {
                choice = Random.Range(0f, weightSum);
            }
            foreach (T t in spawnOptions)
            {
                choice -= WeightOf(t);
                if (choice <= 0)
                {
                    return t;
                }
            }

            // Safety fallback, just return first element
            IEnumerator<T> enumerator = spawnOptions.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }

        /// get a child object of specific name, destroys existing object with that name
        public static GameObject CreateChildWithName(Transform transform, string name) { 
            Transform existingTransform = transform.Find(name);
            for(int i = 0; i < transform.childCount; i++) {
                if(transform.GetChild(i).gameObject.name == name) {
                    GameObject.Destroy(transform.GetChild(i).gameObject);
                }
            }

            GameObject obj = new GameObject(name);
            obj.transform.SetParent(transform, false);

            return obj;
        }
    }
}