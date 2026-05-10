using UnityEngine;

public class Portal2Logic : MonoBehaviour
{
    [Header("Lumile")]
    public GameObject bolVerse;
    public GameObject molVerse;

    [Header("Camerele Video")]
    public GameObject cameraBolVerse;
    public GameObject cameraMolVerse;

    [Header("Jucatorii BolVerse")]
    public GameObject jucator1Bol;
    public GameObject jucator2Bol;

    [Header("Jucatorii MolVerse")]
    public GameObject jucator1Mol;
    public GameObject jucator2Mol;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            
            if (bolVerse != null) bolVerse.SetActive(true);
            if (cameraBolVerse != null) cameraBolVerse.SetActive(true);
            if (jucator1Bol != null) jucator1Bol.SetActive(true);
            if (jucator2Bol != null) jucator2Bol.SetActive(true);

           
            if (molVerse != null) molVerse.SetActive(false);
            if (cameraMolVerse != null) cameraMolVerse.SetActive(false);
            if (jucator1Mol != null) jucator1Mol.SetActive(false);
            if (jucator2Mol != null) jucator2Mol.SetActive(false);

            Debug.Log("Ne-am întors în BolVerse!");
        }
    }
}