using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace cardspace
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public int gold;
        public int exp;
        public int holz;
        public int stein;

        public void Print ()
        {
            UnityEngine.Debug.Log(gold + ":" +  exp);
        }

    }
}
