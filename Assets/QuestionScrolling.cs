using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuestionScrolling : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] panelsPrefab;
    [SerializeField] private GameObject content;
    [SerializeField] private ScrollRect ScrollRect;
    [SerializeField] private GameObject SelectSubjectPanel;

    [SerializeField] private TextMeshProUGUI[] QuestionTexts;
    [SerializeField] private TextMeshProUGUI[] Answers1;
    [SerializeField] private TextMeshProUGUI[] Answers2;
    [SerializeField] private TextMeshProUGUI[] Answers3;
    [SerializeField] private TextMeshProUGUI[] Answers4;

    private int QuestionNum = 0;
    private int SubjectIndex;
    private List<string[]> Questions;

    private void Start()
    {
        
    }

    public void SubjectClicked(int Subject)
    {
        SubjectIndex = Subject;
        Questions = GetData();
        LoadQuestionsToScroll();
    }

    private List<string[]> GetData()
    {
        if (SubjectIndex == 0) return SaveSystem.LoadData().Fyzika;
        if (SubjectIndex == 1) return SaveSystem.LoadData().Matematika;
        Debug.Log("Chyba - Špatný subject index");
        return null;
    }

    private void LoadQuestionsToScroll()
    {
        if(QuestionNum % 3 == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                QuestionTexts[i].text = Questions[GetQuestionNum(i)][0];

                Answers1[i].text = Questions[GetQuestionNum(i)][1];
                Answers2[i].text = Questions[GetQuestionNum(i)][2];
                Answers3[i].text = Questions[GetQuestionNum(i)][3];
                Answers4[i].text = Questions[GetQuestionNum(i)][4];
            }
            return;
        }
        if ((QuestionNum-1) % 3 == 0)
        {
                QuestionTexts[2].text = Questions[GetQuestionNum(1)][0];
            QuestionTexts[0].text = Questions[GetQuestionNum(2)][0];
            QuestionTexts[1].text = Questions[GetQuestionNum(0)][0];

            Answers1[2].text = Questions[GetQuestionNum(1)][1];
            Answers1[0].text = Questions[GetQuestionNum(2)][1];
            Answers1[1].text = Questions[GetQuestionNum(0)][1];

            Answers2[2].text = Questions[GetQuestionNum(1)][2];
            Answers2[0].text = Questions[GetQuestionNum(2)][2];
            Answers2[1].text = Questions[GetQuestionNum(0)][2];

            Answers3[2].text = Questions[GetQuestionNum(1)][3];
            Answers3[0].text = Questions[GetQuestionNum(2)][3];
            Answers3[1].text = Questions[GetQuestionNum(0)][3];

            Answers4[2].text = Questions[GetQuestionNum(1)][4];
            Answers4[0].text = Questions[GetQuestionNum(2)][4];
            Answers4[1].text = Questions[GetQuestionNum(0)][4];
        }
        if ((QuestionNum - 2) % 3 == 0)
        {
            QuestionTexts[2].text = Questions[GetQuestionNum(0)][0];
            QuestionTexts[0].text = Questions[GetQuestionNum(1)][0];
            QuestionTexts[1].text = Questions[GetQuestionNum(2)][0];

            Answers1[2].text = Questions[GetQuestionNum(0)][1];
            Answers1[0].text = Questions[GetQuestionNum(1)][1];
            Answers1[1].text = Questions[GetQuestionNum(2)][1];

            Answers2[2].text = Questions[GetQuestionNum(0)][2];
            Answers2[0].text = Questions[GetQuestionNum(1)][2];
            Answers2[1].text = Questions[GetQuestionNum(2)][2];

            Answers3[2].text = Questions[GetQuestionNum(0)][3];
            Answers3[0].text = Questions[GetQuestionNum(1)][3];
            Answers3[1].text = Questions[GetQuestionNum(2)][3];

            Answers4[2].text = Questions[GetQuestionNum(0)][4];
            Answers4[0].text = Questions[GetQuestionNum(1)][4];
            Answers4[1].text = Questions[GetQuestionNum(2)][4];
        }
    }

    #region QeustioNum

    private int GetQuestionNumFromNegative()
    {
        int i = QuestionNum - 1;
        if(i < 0) i = Questions.Count-1;
        return i;
    }

    private int GetQuestionNum(int i)
    {
        if (i == 0) return GetQuestionNumFromNegative();
        if (i == 1) return QuestionNum;
        if (i == 2) return GetQuestionNumFromPositive();
        return 0;
    }

    private int GetQuestionNumFromPositive()
    {
        int i = QuestionNum + 1;
        if (i >= Questions.Count) i = 0;
        return i;
    }

    #endregion

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
            QuestionNum--;
            if (QuestionNum < 0)
            {
                QuestionNum = Questions.Count - 1;
                ResetPanels();
            }

            LoadQuestionsToScroll();
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
            QuestionNum++;
            if (QuestionNum >= Questions.Count)
            {
                QuestionNum = 0;
                ResetPanels();
            }

            LoadQuestionsToScroll();
        }
    }

    private void ResetPanels()
    {
        GameObject[] help = new GameObject[3];
        help[0] = content.transform.Find("Panel1").gameObject;
        help[1] = content.transform.Find("Panel2").gameObject;
        help[2] = content.transform.Find("Panel3").gameObject;

        panels[0] = help[0];
        panels[1] = help[1];
        panels[2] = help[2];

        panels[0].transform.SetSiblingIndex(0);
        panels[1].transform.SetSiblingIndex(1);
        panels[2].transform.SetSiblingIndex(2);
    }

    private void Update()
    {
        float Y = ScrollRect.verticalNormalizedPosition;
        if(Y < 0.6 && Y > 0.4 && Y < 1 && Y > 0)
            ScrollRect.verticalNormalizedPosition -= LerpPosition(Y);
        else
        ScrollRect.verticalNormalizedPosition += LerpPosition(Y);
    }

    private float LerpPosition(float Y)
    {
        Y -= 0.5f;
        Y = 0.7f*Mathf.Deg2Rad*Mathf.Tan(1.55f*Y);
        //Debug.Log(Y);
        //TODO: vylepsit scroll
        return Y;
    }
}
