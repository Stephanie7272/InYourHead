using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayTrigger : MonoBehaviour
{
    public SkinnedMeshRenderer EnemyMesh;
    public Collider EnemyCollider;
    public EnemyController EnemyController;
    public MeshRenderer SpawnerMesh;
    public Collider SpawnerCollider;
    public GameObject RoomShadows;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyMesh.enabled = true;
            EnemyCollider.enabled = true;
            EnemyController.enabled = true;
            SpawnerMesh.enabled = false;
            SpawnerCollider.enabled = false;
            RoomShadows.SetActive(false);

        }
    }
}