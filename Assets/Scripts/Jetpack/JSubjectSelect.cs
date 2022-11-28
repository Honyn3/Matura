using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class JSubjectSelect : MonoBehaviour
{
    public int SubjectIndex;
    [SerializeField] QuestionScrolling scroll;
    [SerializeField] GameObject ButtonPrefab;
    [SerializeField] GameObject Content;

    private List<GameObject> SubjectList = new List<GameObject>();
    private List<string> SubjectNames;
    private List<int> SubjectIndexes = new List<int>();

    public JMapGenerator gen;

    private void Start()
    {
        Load();
    }
    public void Load()
    {
        foreach (var item in SubjectList)
        {
            GameObject.Destroy(item);
        }
        SubjectList.Clear();
        SubjectIndexes.Clear();

        SubjectNames = SaveSystem.LoadData().SubjectNames;
        for (int i = 0; i < SubjectNames.Count; i++)
        {
            SubjectList.Add(Instantiate(ButtonPrefab, Content.transform));
        }

        int t = 0;
        foreach (var item in SubjectList)
        {
            SubjectIndexes.Add(t);
            item.GetComponentInChildren<TextMeshProUGUI>().text = SubjectNames[t];
            item.name = t.ToString();
            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                ButtonClick(SubjectIndexes[int.Parse(item.name)]);
            });
            t++;
        }

    }

    public void ButtonClick(int i)
    {
        SubjectIndex = i;
        gen.GetQuestions(SaveSystem.LoadData().Ober[i]);

        //SubjectName.text = SubjectNames[SubjectIndex];
        //if (secMan.Section == 0)
        //    scroll.SubjectClicked(SubjectIndex);
        //secMan.ShowScene();
    }
}
