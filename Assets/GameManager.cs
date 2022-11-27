using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void GameClicked(int index)
    {
        if (index == 1) SceneManager.LoadScene(index);
        if (index == 2)
        {
            //SceneManager.LoadScene(index);
        };
        //Je to tak blbe udelane, protoze potrebuju adamovu hru
    }
}
