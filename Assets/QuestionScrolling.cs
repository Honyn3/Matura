using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class QuestionScrolling : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] panelsPrefab;
    [SerializeField] private GameObject content;
    [SerializeField] private ScrollRect ScrollRect;

    public void ScrollChanged(Vector2 Pos)
    {
        if (Pos.y > 0.99)
        {
            GameObject[] help = new GameObject[3];
            help[0] = panels[0];
            help[1] = panels[1];
            help[2] = panels[2];

            panels[0].transform.SetSiblingIndex(1);
            panels[1].transform.SetSiblingIndex(2);
            panels[2].transform.SetSiblingIndex(0);
            panels[0] = help[2];
            panels[1] = help[0];
            panels[2] = help[1];

            ScrollRect.verticalNormalizedPosition = 0.5f;
        }
        if (Pos.y < 0.01)
        {
            GameObject[] help = new GameObject[3];
            help[0] = panels[0];
            help[1] = panels[1];
            help[2] = panels[2];

            panels[0].transform.SetSiblingIndex(2);
            panels[1].transform.SetSiblingIndex(0);
            panels[2].transform.SetSiblingIndex(1);
            panels[0] = help[1];
            panels[1] = help[2];
            panels[2] = help[0];

            ScrollRect.verticalNormalizedPosition = 0.5f;
        }
    }
    private void Update()
    {
        float Y = ScrollRect.verticalNormalizedPosition;
        if(Y < 0.6 && Y > 0.4)
            ScrollRect.verticalNormalizedPosition -= LerpPosition(Y);
        else
        ScrollRect.verticalNormalizedPosition += LerpPosition(Y);
    }

    private float LerpPosition(float Y)
    {
        Y -= 0.5f;
        Y = 0.5f*Mathf.Deg2Rad*Mathf.Tan(1.55f*Y);
        Debug.Log(Y);
        return Y;
    }
}
