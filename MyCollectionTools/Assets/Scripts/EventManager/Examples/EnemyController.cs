using FoxTool;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnEnable()
    {
        UnityEventManager.SubscribeEvent<int>(GameEvents.PlayerNearEnemy, OnPlayerNearEnemy);
    }

    private void OnDisable()
    {
        UnityEventManager.UnsubscribeEvent<int>(GameEvents.PlayerNearEnemy, OnPlayerNearEnemy);
    }

    private void OnPlayerNearEnemy(int c)
    {
        Bounce();
    }

    private void Bounce()
    {
        // Add your enemy bouncing logic here
        Debug.Log("Enemy Bounced");
    }
}

