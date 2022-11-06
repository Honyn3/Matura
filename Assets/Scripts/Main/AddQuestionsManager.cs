using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddQuestionsManager : MonoBehaviour
{
    public int QuestionNum;
    public string[] Question = new string[5];
    public List<string[]> Questions = new List<string[]>();

    [SerializeField] private TMP_InputField InputQuest;
    [SerializeField] private TMP_InputField InputRightAns;
    [SerializeField] private TMP_InputField InputWrong1;
    [SerializeField] private TMP_InputField InputWrong2;
    [SerializeField] private TMP_InputField InputWrong3;
    [SerializeField] private GameObject SelectSubjectClick;

    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AddButtonPress(SelectSubjectClick.GetComponent<SubjectClick>());
        }
        //?? input ??
        //if(TouchScreenKeyboard.Status == TouchScreenKeyboard.Status.Done)
        //{
        //    AddButtonPress(SelectSubjectClick.GetComponent<SubjectClick>());
        //}
    }

    public void AddButtonPress(SubjectClick subjectClick)
    {
        if(InputQuest.text != "") Question[0] = InputQuest.text;
        else
        {
            //Change Color?
            return;
        }
        if (InputRightAns.text != "") Question[1] = InputRightAns.text;
        else
        {
            //Change Color?
            return;
        }
        if (InputWrong1.text != "") Question[2] = InputWrong1.text;
        else
        {
            //Change Color?
            return;
        }
        if (InputWrong2.text != "") Question[3] = InputWrong2.text;
        else
        {
            //Change Color?
            return;
        }
        if (InputWrong3.text != "") Question[4] = InputWrong3.text;
        else
        {
            //Change Color?
            return;
        }

        SaveSystem.SaveData(this, subjectClick);
        ResetText();
        //WriteSaved();
    }

    //public void WriteSaved()
    //{
    //    SaveData data = SaveSystem.LoadData();
    //    Debug.Log("Fyzika:");
    //    List<string[]> listFyzika = data.Fyzika;
    //    foreach (var item in listFyzika)
    //    {
    //        foreach (var a in item)
    //        {
    //            Debug.Log(a);
    //        }
    //    }
    //    Debug.Log("Matematika:");
    //    List<string[]> listMatematika = data.Matematika;
    //    foreach (var item in listMatematika)
    //    {
    //        foreach (var a in item)
    //        {
    //            Debug.Log(a);
    //        }
    //    }
    //    Debug.Log("Later:");
    //    List<string[]> listLater = data.Later;
    //    foreach (var item in listLater)
    //    {
    //        foreach (var a in item)
    //        {
    //            Debug.Log(a);
    //        }
    //    }
    //}

    private void ResetText()
    {
        InputQuest.text = "";
        InputRightAns.text = "";
        InputWrong1.text = "";
        InputWrong2.text = "";
        InputWrong3.text = "";
    }

    public void RemoveButtonClick()
    {
        anim.SetBool("RemoveShow", !anim.GetBool("RemoveShow"));
    }
}
