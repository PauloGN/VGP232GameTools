using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souls : MonoBehaviour
{
    public float soulAmount = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterDataContainer playerREF = other.GetComponent<CharacterDataContainer>();

            if (playerREF != null)
            {
                playerREF.IncreaseSoulPower(soulAmount);
                Destroy(gameObject);
            }
        }
    }
}
