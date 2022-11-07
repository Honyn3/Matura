using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private static Animator mAnim;

    public static void Start()
    {
        mAnim = GameObject.Find("Canvas").GetComponent<Animator>();
        Debug.Log(mAnim);
    }
    public static void LoadSelectSubject()
    {
        mAnim.SetBool("RemoveShow", false);
        mAnim.SetBool("AddQuestionShow", false);
        mAnim.SetBool("AddSubject", false);
        mAnim.SetBool("RemoveSubject", false);
    }
    public static void ShowPanelWhileSelectOff(string name)
    {
        if(!mAnim.GetBool("ToSelectSubject")) mAnim.SetBool(name, true);
    }
}
