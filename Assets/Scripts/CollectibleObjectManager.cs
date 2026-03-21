using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleObjectManager : MonoBehaviour
{
    public int ObjectCounter;
    public TextMeshProUGUI collectibleObjectText;
    public GameObject door;
    private bool doorDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collectibleObjectText.text = ObjectCounter.ToString();
        if(ObjectCounter == 3 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
