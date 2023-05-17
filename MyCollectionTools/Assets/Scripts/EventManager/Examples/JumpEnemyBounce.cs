using FoxTool;
using UnityEngine;

public class JumpEnemyBounce : MonoBehaviour
{
    private void OnEnable()
    {
        UnityEventManager.SubscribeEvent<int>(GameEvents.PlayerJumped, OnPlayerJumped);
        UnityEventManager.SubscribeEvent<int>(GameEvents.PlayerLanded, OnPlayerLanded);
        UnityEventManager.SubscribeEvent<int>(GameEvents.PlayerNearEnemy, OnPlayerNearEnemy);
    }

    private void OnDisable()
    {
        UnityEventManager.UnsubscribeEvent<int>(GameEvents.PlayerJumped, OnPlayerJumped);
        UnityEventManager.UnsubscribeEvent<int>(GameEvents.PlayerLanded, OnPlayerLanded);
        UnityEventManager.UnsubscribeEvent<int>(GameEvents.PlayerNearEnemy, OnPlayerNearEnemy);
    }

    private void OnPlayerJumped(int c)
    {
        Debug.Log("Player Jumped");
    }

    private void OnPlayerLanded(int c)
    {
        Debug.Log("Player Landed");
    }

    private void OnPlayerNearEnemy(int c)
    {
        Debug.Log("Player Near Enemy");
    }
}
