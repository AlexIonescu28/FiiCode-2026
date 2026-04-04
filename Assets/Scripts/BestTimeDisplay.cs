using UnityEngine;
using TMPro;

public class BestTimeDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestTimeText;
    public string levelName = "Lvl1";

    void Start()
    {
        float best = PlayerPrefs.GetFloat(levelName + "_BestTime", float.MaxValue);

        if (best == float.MaxValue)
        {
            bestTimeText.text = "No record yet";
        }
        else
        {
            int minutes = Mathf.FloorToInt(best / 60);
            int seconds = Mathf.FloorToInt(best % 60);

            bestTimeText.text = string.Format("Best Time: {0:00}:{1:00}", minutes, seconds);
        }
    }
}