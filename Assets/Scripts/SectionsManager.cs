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

    private void Start()
    {
        ShowScene();
    }

    public void BtnClicked(int btnIndex)
    {
        if (btnIndex == Section) return;
        HideScene(Section);
        switch (btnIndex)
        {
            case 0: Section = 0; break;
                case 1: Section = 1; break;
            case 2: Section = 2; break;
                case 3: Section = 3; break;
            default:
                break;
        }
        ShowScene();
    }

    private void HideScene(int sec)
    {
        anims[sec].SetBool("Show", false);
    }

    private void ShowScene()
    {
        anims[Section].SetBool("Show", true);
    }
}
