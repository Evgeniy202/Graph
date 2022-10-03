using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Line : MonoBehaviour
{
    public List<string> lines;
    public InputField StartPoint, FinishPoint;
    public GameObject LineObj;
    public Text ResultText;

    public void OnMouseDown()
    {
        int points = GameObject.FindGameObjectsWithTag("Point").Length;
        
        if ((StartPoint.text != null) && (FinishPoint.text != null))
        {
            int startPoint = Int32.Parse(StartPoint.text);
            int finishPoint = Int32.Parse(FinishPoint.text);

            if ((startPoint < points) && (finishPoint < points) && (startPoint != finishPoint))
            {
                string newValue = startPoint + "-" + finishPoint;

                if (!lines.Contains(newValue))
                {
                    lines.Add(newValue);

                    StartPoint.text = "";
                    FinishPoint.text = "";

                    var point_1 = GameObject.Find(startPoint + "_point(Clone)");
                    var point_2 = GameObject.Find(finishPoint + "_point(Clone)");

                    var obj = Instantiate(LineObj, new Vector2(
                        (point_1.transform.position.x + point_2.transform.position.x) / 2,
                        (point_1.transform.position.y + point_2.transform.position.y) /2
                    ), Quaternion.identity);
                    obj.name = newValue;

                    obj.transform.rotation = Quaternion.Euler(
                        transform.rotation.eulerAngles.x, 
                        obj.transform.rotation.eulerAngles.y, 
                        Mathf.Atan2(
                            point_2.transform.position.y - obj.transform.position.y, 
                            point_2.transform.position.x - obj.transform.position.x
                        ) 
                        * Mathf.Rad2Deg
                    );
                }
            }
        }
    }

    public void OnMouseDownRemove()
    {
        if ((StartPoint.text != null) && (FinishPoint.text != null))
        {
            int startPoint = Int32.Parse(StartPoint.text);
            int finishPoint = Int32.Parse(FinishPoint.text);

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i] == startPoint + "-" + finishPoint)
                {
                    Destroy(GameObject.Find(lines[i]));
                    lines.RemoveAt(i);

                    StartPoint.text = "";
                    FinishPoint.text = "";
                }
            }
        }
    }

    public void BtnClickRemovePoint()
    {
        if (lines.Count > 0)
        {
            var linesNow = GameObject.FindGameObjectsWithTag("Line");

            if (linesNow.Length > 1)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    bool exist = false;

                    for (int j = 0; j < linesNow.Length; j++)
                    {
                        if (lines[i] == linesNow[j].name)
                        {
                            exist = true;
                        }
                    }

                    if (exist == false)
                    {
                        lines.RemoveAt(i);
                    }
                }
            }
        }
    }

    public void ClickRemoveAllBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickResultBtn()
    {
        int varibles = GameObject.FindGameObjectsWithTag("Point").Length - 1;
        int[,] result = new int[varibles, varibles];

        ResultText.text = "";

        for (int i = 0; i < varibles; i++)
        {
            for (int j = 0; j < varibles; j++)
            {
                foreach (string el in lines)
                {
                    string[] var = el.Split("-");

                    if (Convert.ToInt32(var[0]) - 1 == i)
                    {
                        result[i, Convert.ToInt32(var[1]) - 1] = 1;
                    }
                }

                if (result[i, j] != 1)
                {
                    result[i, j] = 0;
                }
            }
        }

        var resultText = GameObject.Find("ResultText");

        for (int i = 0; i < varibles; i++)
        {
            for (int j = 0; j < varibles; j++)
            {
                ResultText.text = ResultText.text + result[i, j] + "   ";
            }

            ResultText.text = ResultText.text + "\n";
        }
    }
}
