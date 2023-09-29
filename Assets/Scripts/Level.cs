using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadScene(string Level2)
    {
        SceneManager.LoadScene(Level2);
    }

}