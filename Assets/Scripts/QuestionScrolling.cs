using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


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

    [SerializeField] private Button[] Buttons1;
    [SerializeField] private Button[] Buttons2;
    [SerializeField] private Button[] Buttons3;

    public Sprite WhiteButton;
    public Sprite ButtonSprite1;
    public Sprite ButtonSprite2;
    public Sprite ButtonSprite3;
    public Sprite ButtonSprite4;

    private Color RightColor = new Color(0.063f, 0.78f, 0.122f);
    private Color BadColor = new Color(0.827f, 0.192f, 0.122f);
    private Color Button1Color = new Color(0f, 0.459f, 0.949f);
    private Color Button2Color = new Color(0.169f, 0.753f, 0.086f);
    private Color Button3Color = new Color(0.98f, 0.474f, 0.129f);
    private Color Button4Color = new Color(0.898f, 0.294f, 0.294f);

    private bool Button1Lerp = false;
    private bool Button2Lerp = false;
    private bool Button3Lerp = false;
    public float LerpSpeed;

    private int QuestionNum = 0;
    private int SubjectIndex;
    private List<string[]> Questions;
    private int right;
    private int[] randomOrder;
    private bool changed = true;

    public void SubjectClicked(int Subject)
    {
        SubjectIndex = Subject;
        Questions = GetData();
        randomOrder = GetRandom();
        LoadQuestionsToScroll();
    }

    private List<string[]> GetData()
    {
        if (SubjectIndex == 0) return SaveSystem.LoadData().Fyzika;
        if (SubjectIndex == 1) return SaveSystem.LoadData().Matematika;
        Debug.LogWarning("Chyba - Špatný subject index");
        return null;
    }

    private void LoadQuestionsToScroll()
    {

        right = 0;
        for (int i = 0; i < randomOrder.Length; i++)
        {
            if (randomOrder[i] == 1)
            {
                right = i;
                break;
            }
        }
        Debug.Log("Správná odpověď: " + right);
        
        if(QuestionNum % 3 == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                QuestionTexts[i].text = Questions[GetQuestionNum(i)][0];

                Answers1[i].text = Questions[GetQuestionNum(i)][randomOrder[0]];
                Answers2[i].text = Questions[GetQuestionNum(i)][randomOrder[1]];
                Answers3[i].text = Questions[GetQuestionNum(i)][randomOrder[2]];
                Answers4[i].text = Questions[GetQuestionNum(i)][randomOrder[3]];
            }
            return;
        }
        if ((QuestionNum-1) % 3 == 0)
        {
                QuestionTexts[2].text = Questions[GetQuestionNum(1)][0];
            QuestionTexts[0].text = Questions[GetQuestionNum(2)][0];
            QuestionTexts[1].text = Questions[GetQuestionNum(0)][0];

            Answers1[2].text = Questions[GetQuestionNum(1)][randomOrder[0]];
            Answers1[0].text = Questions[GetQuestionNum(2)][randomOrder[0]];
            Answers1[1].text = Questions[GetQuestionNum(0)][randomOrder[0]];

            Answers2[2].text = Questions[GetQuestionNum(1)][randomOrder[1]];
            Answers2[0].text = Questions[GetQuestionNum(2)][randomOrder[1]];
            Answers2[1].text = Questions[GetQuestionNum(0)][randomOrder[1]];

            Answers3[2].text = Questions[GetQuestionNum(1)][randomOrder[2]];
            Answers3[0].text = Questions[GetQuestionNum(2)][randomOrder[2]];
            Answers3[1].text = Questions[GetQuestionNum(0)][randomOrder[2]];

            Answers4[2].text = Questions[GetQuestionNum(1)][randomOrder[3]];
            Answers4[0].text = Questions[GetQuestionNum(2)][randomOrder[3]];
            Answers4[1].text = Questions[GetQuestionNum(0)][randomOrder[3]];
        }
        if ((QuestionNum - 2) % 3 == 0)
        {
            QuestionTexts[2].text = Questions[GetQuestionNum(0)][0];
            QuestionTexts[0].text = Questions[GetQuestionNum(1)][0];
            QuestionTexts[1].text = Questions[GetQuestionNum(2)][0];

            Answers1[2].text = Questions[GetQuestionNum(0)][randomOrder[0]];
            Answers1[0].text = Questions[GetQuestionNum(1)][randomOrder[0]];
            Answers1[1].text = Questions[GetQuestionNum(2)][randomOrder[0]];

            Answers2[2].text = Questions[GetQuestionNum(0)][randomOrder[1]];
            Answers2[0].text = Questions[GetQuestionNum(1)][randomOrder[1]];
            Answers2[1].text = Questions[GetQuestionNum(2)][randomOrder[1]];

            Answers3[2].text = Questions[GetQuestionNum(0)][randomOrder[2]];
            Answers3[0].text = Questions[GetQuestionNum(1)][randomOrder[2]];
            Answers3[1].text = Questions[GetQuestionNum(2)][randomOrder[2]];

            Answers4[2].text = Questions[GetQuestionNum(0)][randomOrder[3]];
            Answers4[0].text = Questions[GetQuestionNum(1)][randomOrder[3]];
            Answers4[1].text = Questions[GetQuestionNum(2)][randomOrder[3]];
        }
    }

    private int[] GetRandom()
    {
        int[] values = new int[4] {0, 0, 0, 0};
        int ran;
        values[0] = Random.Range(1, 5);

        do
        {
            ran = Random.Range(1, 5);
        } while (values.Contains(ran));
        values[1] = ran;

        do
        {
            ran = Random.Range(1, 5);
        } while (values.Contains(ran));
        values[2] = ran;

        do
        {
            ran = Random.Range(1, 5);
        } while (values.Contains(ran));
        values[3] = ran;

        return values;
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
        if (Pos.y < 0.3 && changed)
        {
            randomOrder = GetRandom();
            changed = false;
        }
        if (Pos.y > 0.7 && changed)
        {
            randomOrder = GetRandom();
            changed = false;
        }
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

            changed = true;
            LoadQuestionsToScroll();
            ResetButtons();
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

            changed = true;
            LoadQuestionsToScroll();
            ResetButtons();
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
        ResetButtons();
    }

    private void Update()
    {
        float Y = ScrollRect.verticalNormalizedPosition;
        if(Y < 0.6 && Y > 0.4 && Y < 1 && Y > 0 && Input.touchCount == 0)
            ScrollRect.verticalNormalizedPosition -= LerpPosition(Y);
        else if(Input.touchCount == 0)
        ScrollRect.verticalNormalizedPosition += LerpPosition(Y);

        if (Button1Lerp)
        {
            for (int i = 0; i < Buttons1.Length; i++)
            {
                if(i == right)
                {
                    Buttons1[i].image.color = Color.Lerp(Buttons1[i].image.color, RightColor, LerpSpeed);
                }
                else
                {
                    Buttons1[i].image.color = Color.Lerp(Buttons1[i].image.color, BadColor, LerpSpeed);
                }
            }
        }
        if (Button2Lerp)
        {
            for (int i = 0; i < Buttons2.Length; i++)
            {
                if (i == right)
                {
                    Buttons2[i].image.color = Color.Lerp(Buttons2[i].image.color, RightColor, LerpSpeed);
                }
                else
                {
                    Buttons2[i].image.color = Color.Lerp(Buttons2[i].image.color, BadColor, LerpSpeed);
                }
            }
        }
        if (Button3Lerp)
        {
            for (int i = 0; i < Buttons3.Length; i++)
            {
                if (i == right)
                {
                    Buttons3[i].image.color = Color.Lerp(Buttons3[i].image.color, RightColor, LerpSpeed);
                }
                else
                {
                    Buttons3[i].image.color = Color.Lerp(Buttons3[i].image.color, BadColor, LerpSpeed);
                }
            }
        }
    }

    private float LerpPosition(float Y)
    {
        Y -= 0.5f;
        Y = 0.7f*Mathf.Deg2Rad*Mathf.Tan(1.55f*Y);
        //Debug.Log(Y);
        //TODO: vylepsit scroll
        return Y;
    }

    private void ResetButtons()
    {
        Button1Lerp = false;
        Button2Lerp = false;
        Button3Lerp = false;

        Buttons1[0].image.sprite = ButtonSprite1;
        Buttons2[0].image.sprite = ButtonSprite1;
        Buttons3[0].image.sprite = ButtonSprite1;

        Buttons1[1].image.sprite = ButtonSprite2;
        Buttons2[1].image.sprite = ButtonSprite2;
        Buttons3[1].image.sprite = ButtonSprite2;

        Buttons1[2].image.sprite = ButtonSprite3;
        Buttons2[2].image.sprite = ButtonSprite3;
        Buttons3[2].image.sprite = ButtonSprite3;

        Buttons1[3].image.sprite = ButtonSprite4;
        Buttons2[3].image.sprite = ButtonSprite4;
        Buttons3[3].image.sprite = ButtonSprite4;

        foreach (var item in Buttons1)
        {
            item.image.color = Color.white;
        }

        foreach (var item in Buttons2)
        {
            item.image.color = Color.white;
        }

        foreach (var item in Buttons3)
        {
            item.image.color = Color.white;
        }
    }

    private void ChangeButtonsColor(Button[] btns)
    {
        btns[0].image.color = Button1Color;
        btns[1].image.color = Button2Color;
        btns[2].image.color = Button3Color;
        btns[3].image.color = Button4Color;

        //for (int i = 0; i < btns.Length; i++)
        //{
        //    btns[i].enabled = false;
        //    btns[i].enabled = true;
        //}
    }

    public void AnswerClicked(int ClickIndex)
    {
        int ButtonsIndex = 0;
        if (QuestionNum % 3 == 0) ButtonsIndex = 2;
        if ((QuestionNum-1) % 3 == 0) ButtonsIndex = 3;
        if ((QuestionNum-2) % 3 == 0) ButtonsIndex = 1;

        switch (ButtonsIndex)
        {
            
            case 1:
                for (int i = 0; i < Buttons1.Length; i++)
                {
                    Buttons1[i].image.sprite = WhiteButton;
                    ChangeButtonsColor(Buttons1);
                    Button1Lerp = true;
                }
                break;
            case 2:
                for (int i = 0; i < Buttons2.Length; i++)
                {
                    Buttons2[i].image.sprite = WhiteButton;
                    ChangeButtonsColor(Buttons2);
                    Button2Lerp = true;
                }
                break;
            case 3:
                for (int i = 0; i < Buttons3.Length; i++)
                {
                    Buttons3[i].image.sprite = WhiteButton;
                    ChangeButtonsColor(Buttons3);
                    Button3Lerp = true;
                }
                break;
            default:
                Debug.Log("Error, switch out of range. ButtonIndex:" + ButtonsIndex);
                break;
        }
        //if (ClickIndex == right) Debug.Log("Right");
        //else
        //{
        //    Debug.Log("False");
        //}
        
    }
}
