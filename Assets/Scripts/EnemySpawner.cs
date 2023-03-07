using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public MeshRenderer EnemyMesh;
    public Collider EnemyCollider;
    public EnemyController EnemyController;
    public MeshRenderer SpawnerMesh;
    public Collider SpawnerCollider;

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnemyMesh.enabled = true;
            EnemyCollider.enabled = true;
            EnemyController.enabled = true;
            SpawnerMesh.enabled = false;
            SpawnerCollider.enabled = false;

        }
    }
}