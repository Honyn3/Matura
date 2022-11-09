using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectionsManager : MonoBehaviour
{
    public int Section = 0;
    [SerializeField] private Button Btn1;
    [SerializeField] private Button Btn2;
    [SerializeField] private Button Btn3;
    [SerializeField] private Button Btn4;
    private Image[] buttons = new Image[4];
    public Sprite[] UnselectedSprites;
    public Sprite[] SelectedSprites;

    [SerializeField] private QuestionScrolling questScroll;
    [SerializeField] private Animator AnimManager;
    [SerializeField] private DeleteSystem delSys;
    [SerializeField] private SubjectDeleteSystem subjectDelSys;
    [SerializeField] private SubjectClick sbjClick;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        AnimatorManager.Start();
        buttons[0] = Btn1.GetComponent<Image>();
        buttons[1] = Btn2.GetComponent<Image>();
        buttons[2] = Btn3.GetComponent<Image>();
        buttons[3] = Btn4.GetComponent<Image>();
        AnimManager.SetBool("ToSelectSubject", true);
    }

    public void BtnClicked(int btnIndex)
    {
        if (btnIndex == Section)
        {
            ResetAnims();
            return;
        }
        if(btnIndex == 0)
        {
            AnimatorManager.ReloadScene();
            questScroll.SubjectClicked(sbjClick.SubjectIndex);
            questScroll.Reload();
        }
        HideScene(Section);
        Section = btnIndex;
        ShowScene();
        SetButtonSprites();
    }

    public void AddQuestionClicked(int btnIndex)
    {
        switch (btnIndex)
        {
            case 0:
                AnimatorManager.ShowPanelWhileSelectOff("AddSubject");
                break;
            case 1:
                AnimatorManager.ShowPanelWhileSelectOff("AddQuestionShow");
                break;
            case 2:
                AnimatorManager.ShowPanelWhileSelectOff("RemoveSubject");
                subjectDelSys.RemoveButtonPressed();
                break;
            case 3:
                AnimatorManager.ShowPanelWhileSelectOff("RemoveShow");
                delSys.RemoveButtonPressed();
                break;
            default:
                break;
        }
        HideScene(1);
    }

    private void SetButtonSprites()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if(i == Section)
            {
                buttons[i].sprite = SelectedSprites[i];
            }
            else
            {
                buttons[i].sprite = UnselectedSprites[i];
            }
        }
    }

    private void HideScene(int sec)
    {
        string BoolName = "Show" + sec.ToString();
        Debug.Log(BoolName);
        AnimManager.SetBool(BoolName, false);
    }

    private void ResetAnims()
    {
        AnimatorManager.ReloadScene();

        ShowScene();
    }

    public void ShowScene()
    {
        string BoolName = "Show" + Section.ToString();
        AnimatorManager.ShowPanelWhileSelectOff(BoolName);
    }

    public void SelectSubjectButtonClicked()
    {
        if (AnimManager.GetBool("ToSelectSubject")) return;

        AnimManager.SetBool("ToSelectSubject", true);
        AnimatorManager.LoadSelectSubject();


        HideScene(Section);
    }
}
