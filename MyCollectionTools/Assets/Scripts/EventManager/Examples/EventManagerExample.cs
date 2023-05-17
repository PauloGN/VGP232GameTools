using UnityEngine;
using FoxTool;

public class EventManagerExample : MonoBehaviour
{

    private void Start()
    {
        // Subscribe to the PlayerSpawned event with a specific event data type
        UnityEventManager.SubscribeEvent<string>(GameEvents.PlayerSpawned, OnPlayerSpawned);
        UnityEventManager.SubscribeEvent<int>(GameEvents.ScoreUpdated, OnScoreUpdated);

        // Trigger the PlayerSpawned event with a specific event data
        PlayerSpawned("Player1");

        // Trigger the ScoreUpdated event with a specific event data
        UpdateScore(100);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the PlayerSpawned event
        UnityEventManager.UnsubscribeEvent<string>(GameEvents.PlayerSpawned, OnPlayerSpawned);
        UnityEventManager.UnsubscribeEvent<int>(GameEvents.ScoreUpdated, OnScoreUpdated);
    }

    private void OnPlayerSpawned(string playerName)
    {
        Debug.Log($"Player Spawned: {playerName}");
    }

    private void OnScoreUpdated(int newScore)
    {
        Debug.Log($"Score Updated: {newScore}");
    }

    private void PlayerSpawned(string playerName)
    {
        UnityEventManager.TriggerEvent<string>(GameEvents.PlayerSpawned, playerName);
    }

    private void UpdateScore(int newScore)
    {
        UnityEventManager.TriggerEvent<int>(GameEvents.ScoreUpdated, newScore);
    }
}
