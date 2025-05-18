using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    public int health = 2;
    public FinalZoneActivator finalZoneActivator; // Añadido
    public GameObject paredHorizontal; // Asigna desde el Inspector o por código


    public bool TakeHit()
    {
        health--;
        if (health <= 0)
        {
            if (finalZoneActivator != null && gameObject.CompareTag("Enemy3"))
            {
                finalZoneActivator.Enemy3Muerto();
            }

            if (gameObject.CompareTag("enemy2"))
            {
                if (paredHorizontal != null)
                    paredHorizontal.SetActive(true);
            }


            Destroy(gameObject);

            return true;
        }
        return false;
    }

}
