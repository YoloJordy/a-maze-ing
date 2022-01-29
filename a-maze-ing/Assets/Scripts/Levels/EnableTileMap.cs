using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnableTileMap : MonoBehaviour
{
    [SerializeField] bool startActive;
    //[SerializeField] KeyCode key = KeyCode.Space;
    [SerializeField] float cooldown = 1;
    float cooldownTimer;

    TilemapRenderer tilemapRenderer;
    TilemapCollider2D tilemapCollider2D;

    bool isEnabled;

    void Start()
    {
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        tilemapRenderer = GetComponent<TilemapRenderer>();

        EnableComponents(startActive);
    }

    void Update()
    {
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && Input.GetKeyDown(GameManager.GM.change)) EnableComponents(!isEnabled);
    }

    void EnableComponents(bool value)
    {
        tilemapRenderer.enabled = value;
        tilemapCollider2D.enabled = value;

        isEnabled = value;
        cooldownTimer = cooldown;
    }
}