using FoxTool;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isJumping = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            UnityEventManager.TriggerEvent<int>(GameEvents.PlayerJumped);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isJumping = false;
            UnityEventManager.TriggerEvent<int>(GameEvents.PlayerLanded);

            if (collision.contacts.Length > 0)
            {
                Vector2 normal = collision.contacts[0].normal;
                if (normal.y > 0.5f)
                {
                    UnityEventManager.TriggerEvent<int>(GameEvents.PlayerNearEnemy);
                }
            }
        }
    }

}
