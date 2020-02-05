﻿using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;           // Reference to the player's heatlh.
        public GameObject[] enemies;                // List of enemy prefabs to be spawned.
        public float spawnTime = 3f;                // How long between each spawn.
        public Transform[] spawnPoints;             // An array of the spawn points this enemy can spawn from.
        private LinkedList<int> spawnPointsBuffer;  //List of spawn points indices that determine the spawn to use on each iteration 


        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
            
            spawnPointsBuffer = new LinkedList<int>();
            int firstIndex = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                spawnPointsBuffer.AddLast((firstIndex + i) % spawnPoints.Length);
            }
        }


        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            var spawnPoint = spawnPointsBuffer.First;
            spawnPointsBuffer.RemoveFirst();
            spawnPointsBuffer.AddLast(spawnPoint);
            var spawnPointIndex = spawnPoint.Value;
            
            Instantiate (enemies[Random.Range(0, enemies.Length)], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}