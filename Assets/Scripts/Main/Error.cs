using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Error : MonoBehaviour
{
    [SerializeField] private Animator mAnim;
    [SerializeField] private TextMeshProUGUI errorText;
    private static Error instace;
    private bool Shown = false;


    void Start()
    {
        mAnim = GameObject.Find("Canvas").GetComponent<Animator>();
        //StartCoroutine(ChangeWeight());
        instace = this;
    }

    private void Update()
    {
        if (Shown)
        {
            Shown = false;
            StartCoroutine(HideInSeconds(2));
        }
    }

    private IEnumerator HideInSeconds(int sec)
    {
        yield return new WaitForSeconds(sec);
        instace.mAnim.SetBool("Error", false);

    }

    private IEnumerator ChangeWeight()
    {
        yield return new WaitForSeconds(1f);
        mAnim.SetLayerWeight(mAnim.GetLayerIndex("Error"), 1);
    }

    public static void ShowErrorMessage(string message)
    {
        instace.mAnim.SetBool("Error", true);
        instace.errorText.text = message;
        instace.Shown = true;
    }
}
