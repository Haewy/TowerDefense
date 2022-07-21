using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tower: MonoBehaviour
{

    //Health
    public int health;//it goes to its mother class: Tower
    //Cost value
    public int cost;//it goes to its mother class: Tower

    public Vector3Int pos;
    public Tilemap spawnTilemap;

    // Lose health and die
    public bool LoseHealth(int damage)
    {
        health--;
        StartCoroutine(Blink());
        if (health == 0)
        {

            Die();
            return true;
        }
        return false;
    }
    public void Die()
    {
        FreeCollider();
        Debug.Log("Tower is dead");
        Destroy(gameObject);
        // Destroy(gameObject, 1.9f);


    }
    public void SetTilePosition(Vector3Int cellPos, Tilemap tilemap)
    {
        this.pos = cellPos;
        this.spawnTilemap = tilemap;
    }
    public void FreeCollider() 
    {
        spawnTilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
    }
    IEnumerator Blink()
    {// Chance color
        GetComponent<SpriteRenderer>().color = Color.red;
        // Wait a moment with changed color
        yield return new WaitForSeconds(.15f);
        // Bring back the original color
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}