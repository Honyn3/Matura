using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<List<string[]>> Ober = new List<List<string[]>>();
    public List<string> SubjectNames = new List<string>();

    //Remove
    public SaveData(int Subject, int Index)
    {
        Ober = SaveSystem.LoadData().Ober;
        SubjectNames = SaveSystem.LoadData().SubjectNames;
        Ober[Subject].RemoveAt(Index);
    }

    //Add to  Ober
    public SaveData(string name)
    {
        Ober = SaveSystem.LoadData().Ober;
        SubjectNames = SaveSystem.LoadData().SubjectNames;

        SubjectNames.Add(name);
        Ober.Add(new List<string[]>());
    }

    //Add question
    public SaveData(AddQuestionsManager addManager, SubjectClick subjectIndex)
    {
        try
        {
            Ober = SaveSystem.LoadData().Ober;
            SubjectNames = SaveSystem.LoadData().SubjectNames;
        }
        catch (System.Exception)
        {
            Debug.Log("Failed to load data! Maybe empty file?");
            return;
        }

        foreach (var item in SubjectNames)
        {
            Debug.Log(item);
        }


        Ober[subjectIndex.SubjectIndex].Add(addManager.Question);
    }

    //Add questions to new subjects
    public SaveData(int subjectIndex)
    {
        try
        {
            Ober = SaveSystem.LoadData().Ober;
            SubjectNames = SaveSystem.LoadData().SubjectNames;
        }
        catch (System.Exception)
        {
            Debug.Log("Failed to load data! Maybe empty file?");
            return;
        }

        foreach (var item in SubjectNames)
        {
            Debug.Log(item);
        }

        foreach (var item in Ober[subjectIndex])
        {
            Ober[Ober.Count - 1].Add(item);
        }
    }

    //Add to later
    public SaveData(string[] Question)
    {
        try
        {
            Ober = SaveSystem.LoadData().Ober;
            SubjectNames = SaveSystem.LoadData().SubjectNames;
        }
        catch (System.Exception)
        {
            Debug.Log("Failed to load data! Maybe empty file?");
            return;
        }
        Ober[2].Add(Question);
    }

    public void RemoveData(int Subject, int Index)
    {
        Ober = SaveSystem.LoadData().Ober;
        SubjectNames = SaveSystem.LoadData().SubjectNames;

        Ober[Subject].RemoveAt(Index);
    }
}
