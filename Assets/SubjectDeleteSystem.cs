using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubjectDeleteSystem : MonoBehaviour
{
    private List<string> subjectNames;
    private List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private SubjectClick subClick;

    public GameObject DeletePrefab;
    public GameObject Content;

    public void RemoveButtonPressed()
    {
        foreach (var item in prefabs)
        {
            GameObject.Destroy(item);
        }
        prefabs.Clear();

        subjectNames = SaveSystem.LoadData().SubjectNames;

        foreach (var item in subjectNames)
        {
            GameObject prefab = Instantiate(DeletePrefab, Content.transform);
            prefabs.Add(prefab);
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = item;
            prefab.GetComponentInChildren<Button>().onClick.AddListener(() => {
                XButton(prefabs.IndexOf(prefab));
            });
        }
    }

    private void XButton(int index)
    {
        Debug.Log(index);
        SaveSystem.RemoveSubject(index);
        GameObject.Destroy(prefabs[index]);
        prefabs.RemoveAt(index);
        subClick.Load();
    }
}
