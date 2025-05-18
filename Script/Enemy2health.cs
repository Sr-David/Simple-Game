using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    public int health = 2;
    public FinalZoneActivator finalZoneActivator; // Añadido


    public bool TakeHit()
    {
        health--;
        if (health <= 0)
        {
            if (finalZoneActivator != null && gameObject.CompareTag("Enemy3"))
            {
                finalZoneActivator.Enemy3Muerto();
            }
            Destroy(gameObject);
            return true;
        }
        return false;
    }

}
