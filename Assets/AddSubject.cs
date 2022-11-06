using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSubject : MonoBehaviour
{
    [SerializeField] private Button FilledButton;
    [SerializeField] private Button EmptyButton;
    [SerializeField] private InputField InputField;
    [SerializeField] private SubjectClick sbjClick;

    [SerializeField] private Sprite ActiveSprite;
    [SerializeField] private Sprite DisabledSprite;

    private bool Empty = true;

    public void AddButtonPressed()
    {
        string name = InputField.text;
        if(name == "")
        {
            //Prazdne
            return;
        }

        
        SaveSystem.AddSubject(name);
        if (!Empty)
        {
            SaveSystem.AddDataToNewSubject(sbjClick.SubjectIndex);
        }
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
