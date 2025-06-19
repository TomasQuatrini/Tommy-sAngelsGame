using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [Header("Animation State Names")]
    public string walkUp    = "WalkUp";
    public string walkDown  = "WalkDown";
    public string walkLeft  = "WalkL";
    public string walkRight = "WalkR";
    public string idleUp    = "IddleUp";
    public string idleDown  = "IddleDown";
    public string idleLeft  = "IddleL";
    public string idleRight = "IddleR";

    private Animator anim;
    private Vector2 lastDir = Vector2.down; // por defecto mirando hacia abajo

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 1) Leemos el input
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // 2) Si hay movimiento, actualizamos lastDir y reproducimos Walk
        if (input.sqrMagnitude > 0.01f)
        {
            lastDir = input.normalized;
            PlayWalk(lastDir);
        }
        // 3) Si no, reproducimos Idle en la última dirección
        else
        {
            PlayIdle(lastDir);
        }
    }

    private void PlayWalk(Vector2 dir)
    {
        // Elegimos eje dominante
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0) anim.Play(walkRight);
            else           anim.Play(walkLeft);
        }
        else
        {
            if (dir.y > 0) anim.Play(walkUp);
            else           anim.Play(walkDown);
        }
    }

    private void PlayIdle(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0) anim.Play(idleRight);
            else           anim.Play(idleLeft);
        }
        else
        {
            if (dir.y > 0) anim.Play(idleUp);
            else           anim.Play(idleDown);
        }
    }
}