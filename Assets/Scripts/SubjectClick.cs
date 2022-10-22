using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectClick : MonoBehaviour
{
    public int SubjectIndex;

    [SerializeField] private GameObject MiddleButton;
    [SerializeField] private GameObject Front;

    private Material middleMaterial;
    private Material frontMaterial;

    
    public Color MatColor;
    public Color FyzColor;

    public float LerpSpeed;

    private Color newCol;
    private bool BtnClicked = false;

    private void Start()
    {
        middleMaterial = MiddleButton.GetComponent<Renderer>().material;
        frontMaterial = Front.GetComponent<Renderer>().material;
    }
    public void ButtonClick(int i)
    {
        //i = 0 => green
        //i = 1 => blue

        BtnClicked = true;
        if (i == 0)
        {
            newCol = FyzColor;
        }
        if (i == 1)
        {
            newCol = MatColor;
        }
        SubjectIndex = i;
        //StartCoroutine(LerpColor(middleMaterial, newCol));
        //StartCoroutine(LerpColor(frontMaterial, newCol));
    }

    private void Update()
    {
        if (BtnClicked == false) return;
        middleMaterial.SetColor("_Color", Color.Lerp(middleMaterial.GetColor("_Color"), newCol, LerpSpeed));
        frontMaterial.SetColor("_Color", Color.Lerp(frontMaterial.GetColor("_Color"), newCol, LerpSpeed));
    }

    private IEnumerator LerpColor(Material m, Color newColor)
    {
        while (m.GetColor("_Color") != newColor)
        {
            yield return new WaitForEndOfFrame();
            m.SetColor("_Color", Color.Lerp(m.GetColor("_Color"), newColor, LerpSpeed));
        }
    }
}
