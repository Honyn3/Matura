using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/data.lol";
    public static void SaveData(AddQuestionsManager addManager, SubjectClick subjectIndex)
    {
        BinaryFormatter formater = new BinaryFormatter();

        Debug.Log(path);
        SaveData data = new SaveData(addManager, subjectIndex);
        FileStream stream = new FileStream(path, FileMode.Create);
        formater.Serialize(stream, data);
        stream.Close();
    }

    public static void RemoveData(int Subject, int Index)
    {
        BinaryFormatter formater = new BinaryFormatter();

        SaveData data = new SaveData(Subject, Index);
        FileStream stream = new FileStream(path, FileMode.Create);
        formater.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
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
