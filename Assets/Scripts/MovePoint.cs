using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    bool MouseDown = false;

    public Transform CentrPoint;
    public float MaxDistance = 4;

    public void OnMouseDown()
    {
        MouseDown = true;
    }

    public void OnMouseUp()
    {
        MouseDown = false;
    }

    private void Update()
    {
        Vector2 Cursor = Input.mousePosition;
        Cursor = Camera.main.ScreenToWorldPoint(Cursor);

        if (MouseDown)
        {
            this.transform.position = Cursor;
        }
    }
}
