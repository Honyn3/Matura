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
            Error.ShowErrorMessage("Chybí otázka");
            return;
        }
        if (InputRightAns.text != "") Question[1] = InputRightAns.text;
        else
        {
            Error.ShowErrorMessage("Chybí správná odpovìï");

            //Change Color?
            return;
        }
        if (InputWrong1.text != "") Question[2] = InputWrong1.text;
        else
        {
            Error.ShowErrorMessage("Chybí špatná odpovìï");

            //Change Color?
            return;
        }
        if (InputWrong2.text != "") Question[3] = InputWrong2.text;
        else
        {
            Error.ShowErrorMessage("Chybí špatná odpovìï");

            //Change Color?
            return;
        }
        if (InputWrong3.text != "") Question[4] = InputWrong3.text;
        else
        {
            Error.ShowErrorMessage("Chybí špatná odpovìï");

            //Change Color?
            return;
        }

        SaveSystem.SaveData(this, subjectClick);
        ResetText();
    }

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
        ResetText();
    }
}
