using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<string[]> Fyzika = new List<string[]>();
    public List<string[]> Matematika = new List<string[]>();

    public SaveData(int Subject, int Index)
    {
        Fyzika = SaveSystem.LoadData().Fyzika;
        Matematika = SaveSystem.LoadData().Matematika;
        if (Subject == 0)
            Fyzika.RemoveAt(Index);
        if (Subject == 1)
            Matematika.RemoveAt(Index);
    }
    public SaveData(AddQuestionsManager addManager, SubjectClick subjectIndex)
    {
        try
        {
            Fyzika = SaveSystem.LoadData().Fyzika;
            Matematika = SaveSystem.LoadData().Matematika;
        }
        catch (System.Exception)
        {
            Debug.Log("Failed to load data! Maybe empty file?");
        }
        

        if (subjectIndex.SubjectIndex == 0)
        Fyzika.Add(addManager.Question);
        if (subjectIndex.SubjectIndex == 1)
        Matematika.Add(addManager.Question);
    }

    public void RemoveData(int Subject, int Index)
    {
        Fyzika = SaveSystem.LoadData().Fyzika;
        Matematika = SaveSystem.LoadData().Matematika;
        if (Subject == 0)
            Fyzika.RemoveAt(Index);
        if (Subject == 1)
            Matematika.RemoveAt(Index);
    }
}
