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
    public GameObject QuestionScrollToReload;

    [SerializeField] private Animator AnimatorManager;
    [SerializeField] private DeleteSystem delSys;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        //ShowScene();
        buttons[0] = Btn1.GetComponent<Image>();
        buttons[1] = Btn2.GetComponent<Image>();
        buttons[2] = Btn3.GetComponent<Image>();
        buttons[3] = Btn4.GetComponent<Image>();
        AnimatorManager.SetBool("ToSelectSubject", true);
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
            QuestionScrollToReload.GetComponent<QuestionScrolling>().Reload();
            AnimatorManager.SetBool("RemoveShow", false);
            AnimatorManager.SetBool("AddQuestionShow", false);
            AnimatorManager.SetBool("AddSubject", false);

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
                AnimatorManager.SetBool("AddSubject", true);
                break;
            case 1:
                AnimatorManager.SetBool("AddQuestionShow", true);
                break;
            case 2:
                break;
            case 3:
                AnimatorManager.SetBool("RemoveShow", true);
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
        AnimatorManager.SetBool(BoolName, false);
    }

    private void ResetAnims()
    {
        //AnimatorManager.SetBool("SelectSubject", false);
        AnimatorManager.SetBool("RemoveShow", false);
        AnimatorManager.SetBool("AddQuestionShow", false);
        AnimatorManager.SetBool("AddSubject", false);

        ShowScene();
    }

    public void ShowScene()
    {
        string BoolName = "Show" + Section.ToString();
        AnimatorManager.SetBool(BoolName, true);
    }

    public void SelectSubjectButtonClicked()
    {
        if (AnimatorManager.GetBool("ToSelectSubject")) return;

        AnimatorManager.SetBool("ToSelectSubject", true);
        AnimatorManager.SetBool("RemoveShow", false);
        AnimatorManager.SetBool("AddQuestionShow", false);
        AnimatorManager.SetBool("AddSubject", false);

        HideScene(Section);
    }
}
