using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubjectClick : MonoBehaviour
{
    public int SubjectIndex;
    private Animator anim;
    [SerializeField] TextMeshProUGUI[] SubjectNames;

    //[SerializeField] private GameObject MiddleButton;
    //[SerializeField] private GameObject Front;

    //private Material middleMaterial;
    //private Material frontMaterial;

    
    //public Color MatColor;
    //public Color FyzColor;

    //public float LerpSpeed;

    //private Color newCol;
    //private bool BtnClicked = false;

    private void Start()
    {
        anim = GameObject.Find("Canvas").GetComponent<Animator>();
        anim.SetBool("SelectSubject", false);
        //middleMaterial = MiddleButton.GetComponent<Renderer>().material;
        //frontMaterial = Front.GetComponent<Renderer>().material;
    }
    public void ButtonClick(int i)
    {
        //i = 0 => green
        //i = 1 => blue

        //BtnClicked = true;
        //if (i == 0)
        //{
        //    newCol = FyzColor;
        //}
        //if (i == 1)
        //{
        //    newCol = MatColor;
        //}
        SubjectIndex = i;
        anim.SetBool("SelectSubject", true);

        foreach (var item in SubjectNames)
        {
            if (SubjectIndex == 0)
                item.text = "Fyzika";
            if (SubjectIndex == 1)
                item.text = "Matematika";
        }
    }

    //private void Update()
    //{
        //if (BtnClicked == false) return;
        //middleMaterial.SetColor("_Color", Color.Lerp(middleMaterial.GetColor("_Color"), newCol, LerpSpeed));
        //frontMaterial.SetColor("_Color", Color.Lerp(frontMaterial.GetColor("_Color"), newCol, LerpSpeed));
    //}
}
