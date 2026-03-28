using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

public class LevelSelector : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Lvl"+level.ToString());
    }
}
