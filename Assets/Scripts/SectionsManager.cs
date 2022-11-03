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

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        ShowScene();
        buttons[0] = Btn1.GetComponent<Image>();
        buttons[1] = Btn2.GetComponent<Image>();
        buttons[2] = Btn3.GetComponent<Image>();
        buttons[3] = Btn4.GetComponent<Image>();
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
        }
        HideScene(Section);
        Section = btnIndex;
        ShowScene();
        SetButtonSprites();
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

    //private IEnumerator WaitAndReset(Animator animator)
    //{
    //    yield return new WaitForSeconds(1f);
    //    animator.Rebind();
    //    animator.Update(0f);
    //}

    private void ResetAnims()
    {
        AnimatorManager.SetBool("SelectSubject", false);
        ShowScene();
    }

    private void ShowScene()
    {
        string BoolName = "Show" + Section.ToString();
        AnimatorManager.SetBool(BoolName, true);
    }
}
