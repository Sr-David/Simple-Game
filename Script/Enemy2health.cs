using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    public int health = 2;

    public void TakeHit()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
