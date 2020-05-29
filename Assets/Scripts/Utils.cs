using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Int32;

public class Utils {
    public static int[] ShuffleArray (int[] arr) {
        int[] newArr = arr.Clone() as int[];
        for (int i = 0; i < newArr.Length; i += 1) {
            var tmp = newArr[i];
            var rnd = Random.Range(i, newArr.Length);
            newArr[i] = newArr[rnd];
            newArr[rnd] = tmp;
        }
        return newArr;
    }
    public static bool IsPlural(int n) {
        var str = n.ToString();
        var num = Parse(str.Substring(str.Length - 1).ToString());
        if (n > 10) {
            var numDec = Parse(str.Substring(str.Length - 2).ToString());
            if (numDec == 12 || numDec == 13 || numDec == 14) return false;
        }
        return num == 2 || num == 3 || num == 4;
    }


}
