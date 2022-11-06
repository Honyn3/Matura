using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToLater : MonoBehaviour
{
    [SerializeField] private GameObject Scroll;
    [SerializeField] private GameObject AddMan;
    private string[] Question;

    public void SaveToLaterButton()
    {
        //AddQuestionsManager addManager = AddMan.GetComponent<AddQuestionsManager>();
        //addManager.Question = Question;
        Question = Scroll.GetComponent<QuestionScrolling>().Questions[Scroll.GetComponent<QuestionScrolling>().QuestionNum];
        SaveSystem.SaveData(Question);
    }
}
