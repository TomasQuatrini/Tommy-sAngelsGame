using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 _checkpointPosition;
    private Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _checkpointPosition = transform.position;
    }

    public void SetCheckPoint(Vector2 newCheckpoint)
    {
        _checkpointPosition = newCheckpoint;
        Debug.Log("Se guardo un nuevo checkpoint");
    }

    public void Respawn()
    {
        _rb.velocity = Vector2.zero;
        transform.position = _checkpointPosition;
    }
}
