using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    private int counter = 0;

    public Vector3[] randomEnemyStart;
    public static RandomPositions access;
    // Start is called before the first frame update
    void Start()
    {
        access = this;
    }
    public Vector3 GetRandomPosition()
    {
        counter++;
        if (counter >=randomEnemyStart.Length)
            counter = 0;

        return randomEnemyStart[counter];
      //  return Vector3.zero;
    }
}
