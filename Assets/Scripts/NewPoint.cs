using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPoint : MonoBehaviour
{
    public GameObject[] points;
    public int num = 0;

    public void OnButtonDown()
    {
        if (num < points.Length)
        {
            Instantiate(points[num], new Vector2(0, 0), Quaternion.identity);
            num++;
        }
    }
    
    public void OnButtonClickRemove()
    {
        if (num > 0)
        {
            num--;
        }
    }
}
