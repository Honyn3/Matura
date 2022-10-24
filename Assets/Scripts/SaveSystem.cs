using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(AddQuestionsManager addManager, SubjectClick subjectIndex)
    {
        BinaryFormatter formater = new BinaryFormatter();

        string path = Application.persistentDataPath + "/data.lol";
        

        SaveData data = new SaveData(addManager, subjectIndex);
        FileStream stream = new FileStream(path, FileMode.Create);
        formater.Serialize(stream, data);
        stream.Close();
    }

    public static void RemoveData(int Subject, int Index)
    {
        BinaryFormatter formater = new BinaryFormatter();

        string path = Application.persistentDataPath + "/data.lol";


        SaveData data = new SaveData(Subject, Index);
        FileStream stream = new FileStream(path, FileMode.Create);
        formater.Serialize(stream, data);
        stream.Close();
    }

    //public static void RemoveData(int Subject, int index, AddQuestionsManager addManager, SubjectClick subjectIndex)
    //{
    //    SaveData data = new SaveData(addManager, subjectIndex);
    //    data.RemoveData(Subject, index);
    //    SaveData(addManager, subjectIndex);
    //    SaveData data = LoadData();
    //    if (Subject == 0)
    //    {
    //        data.Fyzika.RemoveAt(index);
    //    }
    //    if (Subject == 1)
    //    {
    //        data.Matematika.RemoveAt(index);
    //    }
    //}

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/data.lol";
        if (File.Exists(path))
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formater.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Not found data, path: " + path);
            return null;
        }
    }
}
