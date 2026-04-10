using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossCollectibleObjectManager : MonoBehaviour
{
    public int ObjectCounter;
    public TextMeshProUGUI collectibleObjectText;
    public GameObject door;
    private bool doorDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        ObjectCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectCounter == 1 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
