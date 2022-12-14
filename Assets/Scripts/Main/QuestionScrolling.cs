using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestionScrolling : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject content;
    [SerializeField] private ScrollRect ScrollRect;
    [SerializeField] private GameObject QuestionsPanel;

    [SerializeField] private TextMeshProUGUI[] QuestionTexts;
    [SerializeField] private TextMeshProUGUI[] Answers1;
    [SerializeField] private TextMeshProUGUI[] Answers2;
    [SerializeField] private TextMeshProUGUI[] Answers3;
    [SerializeField] private TextMeshProUGUI[] Answers4;

    [SerializeField] private Button[] Buttons1;
    [SerializeField] private Button[] Buttons2;
    [SerializeField] private Button[] Buttons3;

    [SerializeField] private Animator CheckAnim;

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
    public float ScrollLerpSpeed;

    public int QuestionNum = 0;
    private int SubjectIndex;
    public List<string[]> Questions;
    private int right;
    private int[] randomOrder;
    private bool changed = true;
    private bool[] Answered;

    [SerializeField] private GameObject DonePanel;
    [SerializeField] private TextMeshProUGUI Percentil;
    [SerializeField] private TextMeshProUGUI RightAnswered;
    [SerializeField] private TextMeshProUGUI WrongAnswered;
    private float RightAnswers = 0, WrongAnswers = 0;

    public void SubjectClicked(int Subject)
    {
        SubjectIndex = Subject;
        Reload();
    }

    public void Reload()
    {
        Questions = GetData();
        Debug.Log(Questions.Count);
        if (Questions == null)
        {
            AnimatorManager.LoadSelectSubject();
            return;
        }
        Answered = new bool[Questions.Count];
        for (int i = 0; i < Answered.Length; i++)
        {
            Answered[i] = false;
        }
        randomOrder = GetRandom();
        LoadQuestionsToScroll();
        RightAnswers = 0;
        WrongAnswers = 0;
    }

    private List<string[]> GetData()
    {
        try
        {
            return SaveSystem.LoadData().Ober[SubjectIndex];
        }
        catch (System.Exception)
        {
            Debug.Log("Missing data in file!");
        }

        Debug.LogWarning("Chyba - ??patn?? subject index");
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
        Debug.Log("Spr??vn?? odpov????: " + right);

        if (Questions.Count == 1)
        {
            AnimatorManager.LoadSelectSubject();
            Error.ShowErrorMessage("Slo??ka mus?? obsahovat alespo?? 2 ot??zky");
            Debug.Log("ENot enough questions");
            return;
        }
        if (Questions.Count == 0)
        {
            AnimatorManager.LoadSelectSubject();
            Error.ShowErrorMessage("Pr??zdn?? slo??ka");
            Debug.Log("Empty file");
            return;
        }

        if (QuestionNum % 3 == 0)
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
        if ((QuestionNum - 1) % 3 == 0)
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
        int[] values = new int[4] { 0, 0, 0, 0 };
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
        if (i < 0) i = Questions.Count - 1;
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
            if (Answered[QuestionNum] == true) CheckAnim.SetBool("Show", true);
            else CheckAnim.SetBool("Show", false);
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
                if (AnsweredTrue())
                {
                    RightAnswered.text = RightAnswers.ToString();
                    WrongAnswered.text = WrongAnswers.ToString();
                    Percentil.text = (GetPercentile(RightAnswers / (RightAnswers + WrongAnswers)).ToString() + "%");
                    AnimatorManager.ShowDonePanel();
                    DonePanel.GetComponent<Image>().material.SetFloat("_Percentile", RightAnswers / (RightAnswers + WrongAnswers));
                }
            }

            changed = true;
            LoadQuestionsToScroll();
            ResetButtons();
            if (Answered[QuestionNum] == true) CheckAnim.SetBool("Show", true);
            else CheckAnim.SetBool("Show", false);
        }
    }

    public void HideDonePanel()
    {
        Debug.Log("Hide");
        AnimatorManager.HideDonePanel();
        RightAnswers = 0;
        WrongAnswers = 0;
        for (int i = 0; i < Answered.Length; i++)
        {
            Answered[i] = false;
        }
        CheckAnim.SetBool("Show", false);
    }

    private float GetPercentile(float num)
    {
        num = num * 100;
        int ret = Mathf.RoundToInt(num);
        return ret;
    }

    private bool AnsweredTrue()
    {
        bool ans = true;
        foreach (var item in Answered)
        {
            if (item == false) ans = false;
        }
        return ans;
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
        if (Y < 0.6 && Y > 0.4 && Y < 1 && Y > 0 && Input.touchCount == 0)
            ScrollRect.verticalNormalizedPosition -= LerpPosition(Y);
        else if (Input.touchCount == 0)
            ScrollRect.verticalNormalizedPosition += LerpPosition(Y);

        if (Button1Lerp)
        {
            for (int i = 0; i < Buttons1.Length; i++)
            {
                if (i == right)
                {
                    Buttons1[i].image.color = Color.Lerp(Buttons1[i].image.color, RightColor, LerpSpeed * Time.deltaTime);
                }
                else
                {
                    Buttons1[i].image.color = Color.Lerp(Buttons1[i].image.color, BadColor, LerpSpeed * Time.deltaTime);
                }
            }
        }
        if (Button2Lerp)
        {
            for (int i = 0; i < Buttons2.Length; i++)
            {
                if (i == right)
                {
                    Buttons2[i].image.color = Color.Lerp(Buttons2[i].image.color, RightColor, LerpSpeed * Time.deltaTime);
                }
                else
                {
                    Buttons2[i].image.color = Color.Lerp(Buttons2[i].image.color, BadColor, LerpSpeed * Time.deltaTime);
                }
            }
        }
        if (Button3Lerp)
        {
            for (int i = 0; i < Buttons3.Length; i++)
            {
                if (i == right)
                {
                    Buttons3[i].image.color = Color.Lerp(Buttons3[i].image.color, RightColor, LerpSpeed * Time.deltaTime);
                }
                else
                {
                    Buttons3[i].image.color = Color.Lerp(Buttons3[i].image.color, BadColor, LerpSpeed * Time.deltaTime);
                }
            }
        }

    }

    private void OnDisable()
    {
        CheckAnim.SetBool("Show", false);
    }

    private float LerpPosition(float Y)
    {
        Y -= 0.5f;
        Y = 0.7f * Mathf.Deg2Rad * Mathf.Tan(1.55f * Y) * Time.deltaTime * ScrollLerpSpeed;
        //Debug.Log(Y);
        //TODO: vylepsit scroll
        return Y;
    }

    private void ResetButtons()
    {
        Button1Lerp = false;
        Button2Lerp = false;
        Button3Lerp = false;

        Buttons3[0].image.sprite = ButtonSprite1;
        Buttons3[1].image.sprite = ButtonSprite2;
        Buttons3[2].image.sprite = ButtonSprite3;
        Buttons3[3].image.sprite = ButtonSprite4;
        foreach (var item in Buttons3)
        {
            item.image.color = Color.white;
        }

        Buttons1[0].image.sprite = ButtonSprite1;
        Buttons1[1].image.sprite = ButtonSprite2;
        Buttons1[2].image.sprite = ButtonSprite3;
        Buttons1[3].image.sprite = ButtonSprite4;
        foreach (var item in Buttons1)
        {
            item.image.color = Color.white;
        }

        Buttons2[0].image.sprite = ButtonSprite1;
        Buttons2[1].image.sprite = ButtonSprite2;
        Buttons2[2].image.sprite = ButtonSprite3;
        Buttons2[3].image.sprite = ButtonSprite4;
        foreach (var item in Buttons2)
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
    }

    public void AnswerClicked(int ClickIndex)
    {
        if (ClickIndex == right && Answered[QuestionNum] == false) RightAnswers++;
        else if (Answered[QuestionNum] == false)
        {
            WrongAnswers++;
        }

        char btnIndex = content.transform.GetChild(1).name[5];
        int ButtonsIndex = btnIndex - '0';

        Answered[QuestionNum] = true;
        CheckAnim.SetBool("Show", true);
        Debug.Log("Question Num " + QuestionNum + ", ButtonsIndex " + ButtonsIndex);

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
        

    }
}
