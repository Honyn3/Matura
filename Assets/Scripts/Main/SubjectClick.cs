using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class SubjectClick : MonoBehaviour
{
    public int SubjectIndex;
    private Animator anim;
    [SerializeField] TextMeshProUGUI SubjectName;
    [SerializeField] QuestionScrolling scroll;
    [SerializeField] GameObject ButtonPrefab;
    [SerializeField] GameObject Content;

    [SerializeField] TMP_InputField SubjectAddInput;
    [SerializeField] SectionsManager secMan;

    private List<GameObject> SubjectList = new List<GameObject>();
    private List<string> SubjectNames;
    private List<int> SubjectIndexes = new List<int>();

    private void Start()
    {
        Load();
    }
    private void Load()
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

        anim = GameObject.Find("Canvas").GetComponent<Animator>();
        anim.SetBool("SelectSubject", false);
    }

    public void ButtonClick(int i)
    {
        SubjectIndex = i;
        anim.SetBool("SelectSubject", true);
        anim.SetBool("ToSelectSubject", false);

        SubjectName.text = SubjectNames[SubjectIndex];
        scroll.SubjectClicked(SubjectIndex);
        secMan.ShowScene();
    }

    public void SubjectAdd() 
    {
        string name = SubjectAddInput.text;
        if (name == "") return;

        SaveSystem.AddSubject(name);
        Load();
    }
}
