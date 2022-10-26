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

    [SerializeField] private Animator[] anims = new Animator[4];
    [SerializeField] private Animator AnimatorManager;

    private void Start()
    {
        ShowScene();
    }

    public void BtnClicked(int btnIndex)
    {
        if (btnIndex == Section)
        {
            //ResetAnims(anims[btnIndex]);
            ResetAnims();
            return;
        }
        HideScene(Section);
        Section = btnIndex;
        ShowScene();
    }

    private void HideScene(int sec)
    {
        string BoolName = "Show" + sec.ToString();
        Debug.Log(BoolName);
        AnimatorManager.SetBool(BoolName, false);
        //StartCoroutine(WaitAndReset(AnimatorManager));
    }

    private IEnumerator WaitAndReset(Animator animator)
    {
        yield return new WaitForSeconds(1f);
        animator.Rebind();
        animator.Update(0f);
    }

    private void ResetAnims()
    {
        AnimatorManager.SetBool("SelectSubject", false);
        //animator.Rebind();
        //animator.Update(0f);
        ShowScene();
    }

    private void ShowScene()
    {
        string BoolName = "Show" + Section.ToString();
        AnimatorManager.SetBool(BoolName, true);
    }
}
