using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] private Button btn;
    private Image _renderer;

    private void Start()
    {
        _renderer = GameObject.Find("Button").GetComponent<Image>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            _renderer.material.SetInt("_Rotate", Mathf.Abs(_renderer.material.GetInt("_Rotate")-1));
            Debug.Log("Button Pressed");
            GetComponent<ShowButtonsSpace>().ShowButtonSpace();
        });
    }
}
