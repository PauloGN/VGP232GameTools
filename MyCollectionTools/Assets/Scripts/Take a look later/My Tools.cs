using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MyTools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class EnemyController : MonoBehaviour
{

    // Declare a variable for the prefab of the enemy object to be spawned
    public GameObject enemyPrefab;

    // Declare a function to be called by the button in the Inspector
    public void SpawnEnemy()
    {
        // Choose a random position within a range of x and z values
        float randomX = UnityEngine.Random.Range(-10f, 10f);
        float randomZ = UnityEngine.Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);

        // Instantiate a new instance of the enemy object at the random position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    public enum EnemyState
    {
        Chasing,
        Attacking,
        Patrolling
    }
    private EnemyState currentState = EnemyState.Patrolling;
    public void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            Debug.Log("Changing from " + currentState + " to " + newState);
            currentState = newState;
        }
    }
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Chasing:
                ChasePlayer();
                break;
            case EnemyState.Attacking:
                AttackPlayer();
                break;
            case EnemyState.Patrolling:
                PatrolArea();
                break;
        }
    }
    private void ChasePlayer()
    {
        // Implemente o comportamento de perseguir o jogador aqui
        // Exemplo:
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(playerTransform);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 3f * Time.deltaTime);
    }
    private void AttackPlayer()
    {
        // Implemente o comportamento de atacar o jogador aqui
        // Exemplo:
        Debug.Log("Attacking Player!");
    }
    private void PatrolArea()
    {
        // Implemente o comportamento de patrulhar a área aqui
        // Exemplo:
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }
}

[CustomEditor(typeof(EnemyController))]
public class EnemyControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        // Add a button to the Inspector for spawning an enemy
        if (GUILayout.Button("Spawn Enemy"))
        {
            EnemyController enemyController = (EnemyController)target;
            enemyController.SpawnEnemy();
        }
    }
}