using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public float radius;
    public LayerMask enemies;
    public LayerMask destructibleObjects;
    public LayerMask bossLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Attacking(); 

        }
    }

    void Attacking()
    {
        Collider2D[] taged = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemies);
        Collider2D[] destroyed = Physics2D.OverlapCircleAll(attackPoint.position, radius, destructibleObjects);
        Collider2D[] bosses = Physics2D.OverlapCircleAll(attackPoint.position, radius, bossLayer);
        foreach (Collider2D enemy in taged)
        {
            Destroy(enemy.gameObject);

            
            Debug.Log("Inamicul " + enemy.name + " a fost distrus instantaneu!");
        }

        foreach (Collider2D objects in destroyed)
        {
            Destroy(objects.gameObject);


            Debug.Log("Obiectul " + objects.name + " a fost distrus instantaneu!");
        }

        

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
