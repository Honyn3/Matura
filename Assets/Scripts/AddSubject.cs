using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddSubject : MonoBehaviour
{
    [SerializeField] private Button FilledButton;
    [SerializeField] private Button EmptyButton;
    [SerializeField] private TMP_InputField InputField;
    [SerializeField] private SubjectClick sbjClick;

    [SerializeField] private Sprite ActiveSprite;
    [SerializeField] private Sprite DisabledSprite;

    public bool Empty = true;

    public void AddButtonPressed()
    {
        string name = InputField.text;
        if(name == "")
        {
            //Prazdne
            return;
        }
        InputField.text = "";

        SaveSystem.AddSubject(name);
        if (!Empty)
        {
            SaveSystem.AddDataToNewSubject(sbjClick.SubjectIndex);
        }
        sbjClick.Load();
    }

    public void EmptyButtonClick()
    {
        Empty = true;
        FilledButton.image.sprite = DisabledSprite;
        EmptyButton.image.sprite = ActiveSprite;

    }

    public void FilledButtonClick()
    {
        Empty = false;
        FilledButton.image.sprite = ActiveSprite;
        EmptyButton.image.sprite = DisabledSprite;

    }
}
