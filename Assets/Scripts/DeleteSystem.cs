using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSystem : MonoBehaviour
{
    private List<string[]> Questions = new List<string[]>();
    [SerializeField] private GameObject ButtonClickObject;
    private List<GameObject> prefabs = new List<GameObject>();

    public GameObject DeletePrefab;
    public GameObject Content;
    private int Subject;
    private int Index = 0;


    public void RemoveButtonPressed()
    {
        foreach (var item in prefabs)
        {
            GameObject.Destroy(item);
        }
        prefabs.Clear();
        Subject = ButtonClickObject.GetComponent<SubjectClick>().SubjectIndex;

        if(Subject == 0)
        {
            Questions = SaveSystem.LoadData().Fyzika;
        }
        if (Subject == 1)
        {
            Questions = SaveSystem.LoadData().Matematika;
        }
        if (Subject == 2)
        {
            Questions = SaveSystem.LoadData().Later;
        }
        Debug.Log("Poèet questions: " + Questions.Count);

        foreach (var item in Questions)
        {
            GameObject prefab = Instantiate(DeletePrefab, Content.transform);
            prefabs.Add(prefab);
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = item[0];
            prefab.GetComponentInChildren<Button>().onClick.AddListener(() => {
                XButton(prefabs.IndexOf(prefab));
            });
            Index++;
        }
    }

    private void XButton(int index)
    {
        Debug.Log(index);
        SaveSystem.RemoveData(Subject, index);
        GameObject.Destroy(prefabs[index]);
        prefabs.RemoveAt(index);
    }
}
