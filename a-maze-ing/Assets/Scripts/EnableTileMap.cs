using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnableTileMap : MonoBehaviour
{
    [SerializeField] bool startActive;
    [SerializeField] KeyCode key = KeyCode.Space;

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
        if (Input.GetKeyDown(key)) EnableComponents(!isEnabled);
    }

    void EnableComponents(bool value)
    {
        tilemapRenderer.enabled = value;
        tilemapCollider2D.enabled = value;

        isEnabled = value;
    }
}
