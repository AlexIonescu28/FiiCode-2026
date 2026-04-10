using UnityEngine;

public class BossHitEvents : MonoBehaviour
{
    private int hitCount = 0;

    [Header("Hit 1")]
    public GameObject[] hideOnHit1;   // BossDestructibleObject
    public GameObject[] showOnHit1;   // BossDestructibleObject2

    [Header("Hit 2")]
    public GameObject[] hideOnHit2;   // BossDestructibleObject2
    public GameObject[] showOnHit2;   // BossDestructibleObject3

    public void RegisterHit()
    {
        hitCount++;

        if (hitCount == 1)
        {
            HandleHit1();
        }
        else if (hitCount == 2)
        {
            HandleHit2();
        }
        else if (hitCount == 3)
        {
            // faza 3 dacă vrei
        }
    }

    private void HandleHit1()
    {
        foreach (GameObject obj in hideOnHit1)
            if (obj != null) obj.SetActive(false);

        foreach (GameObject obj in showOnHit1)
            if (obj != null) obj.SetActive(true);
    }

    private void HandleHit2()
    {
        foreach (GameObject obj in hideOnHit2)
            if (obj != null) obj.SetActive(false);

        foreach (GameObject obj in showOnHit2)
            if (obj != null) obj.SetActive(true);
    }
}
