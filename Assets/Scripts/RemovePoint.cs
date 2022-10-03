using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RemovePoint : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (0 < GameObject.FindGameObjectsWithTag("Point").Length - 1)
        {
            int n = GameObject.FindGameObjectsWithTag("Point").Length - 1;

            Destroy(GameObject.FindGameObjectsWithTag("Point")[
                GameObject.FindGameObjectsWithTag("Point").Length - 1
            ]);

            var points = GameObject.FindGameObjectsWithTag("Line");
            for (int i = 0; i < points.Length; i++)
            {
                string name = points[i].name;
                string[] nameList = name.Split("-");

                if ((Convert.ToInt32(nameList[0]) == n) | (Convert.ToInt32(nameList[1]) == n))
                {
                    Destroy(points[i]);
                }
            }
        }
    }
}
