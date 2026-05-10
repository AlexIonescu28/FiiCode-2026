using UnityEngine;

public class PortalManagerCoop : MonoBehaviour
{
    [Header("Dimensiunile")]
    public GameObject bolVerse;
    public GameObject molVerse;

    [Header("Camerele Video")]
    public GameObject cameraBolVerse;
    public GameObject cameraMolVerse;

    [Header("Jucatorii BolVerse (Platformer)")]
    public GameObject jucator1Bol;
    public GameObject jucator2Bol;

    [Header("Jucatorii MolVerse (Top-Down)")]
    public GameObject jucator1Mol;
    public GameObject jucator2Mol;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("player"))
        {
          
            if (bolVerse != null) bolVerse.SetActive(false);
            if (cameraBolVerse != null) cameraBolVerse.SetActive(false);
            if (jucator1Bol != null) jucator1Bol.SetActive(false);
            if (jucator2Bol != null) jucator2Bol.SetActive(false);

           
            if (molVerse != null) molVerse.SetActive(true);
            if (cameraMolVerse != null) cameraMolVerse.SetActive(true);
            if (jucator1Mol != null) jucator1Mol.SetActive(true);
            if (jucator2Mol != null) jucator2Mol.SetActive(true);

            Debug.Log("Tranziție reușită către MolVerse!");
        }
    }
}