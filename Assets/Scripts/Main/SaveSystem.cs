using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using static UnityEditor.Rendering.CameraUI;

public static class SaveSystem
{
    static string path = Application.dataPath + "/data.txt";
    public static void SaveData(AddQuestionsManager addManager, SubjectClick subjectIndex)
    {
        BinaryFormatter formater = new BinaryFormatter();

        Debug.Log(path);
        SaveData data = new SaveData(addManager, subjectIndex);
        FileStream stream = new FileStream(path, FileMode.Create);
        formater.Serialize(stream, data);
        
        stream.Close();
    }

    public static void SaveData(string[] Question)
    {
        BinaryFormatter formater = new BinaryFormatter();

        Debug.Log(path);
        SaveData data = new SaveData(Question);
        FileStream stream = new FileStream(path, FileMode.Create);
        formater.Serialize(stream, data);

        stream.Close();
    }

    public static void AddDataToNewSubject(int SubjectIndex)
    {
        BinaryFormatter formater = new BinaryFormatter();

        Debug.Log(path);
        SaveData data = new SaveData(SubjectIndex);
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

    public static void AddSubject(string name)
    {
        BinaryFormatter formater = new BinaryFormatter();

        SaveData data = new SaveData(name);
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
            SaveData data;
            try
            {
                data = formater.Deserialize(stream) as SaveData;
            }
            catch (Exception)
            {
                Debug.LogError("No data in stream!");
                stream.Close();
                return null;
            }

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
