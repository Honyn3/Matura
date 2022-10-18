using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShowButtonsSpace : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject panel;

    private void Start()
    {

        anim = panel.GetComponent<Animator>();
    }

    private void Update()
    {
        if (panel.activeInHierarchy && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            anim.SetTrigger("Leave");
            StartCoroutine(WaitAndDisable());
        }
    }

    public void ShowButtonSpace()
    {
        if(!panel.activeInHierarchy)
        panel.SetActive(true);
        else
        {
            anim.SetTrigger("Leave");
            StartCoroutine(WaitAndDisable());
        }
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }
}
