using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Test_Spawner : MonoBehaviour
{
    public SpriteRenderer test;

    public List<GameObject> towerPrefabs;
    public List<Image> towersUI;
    private int spawnID = -1;
    public Tilemap spawnTilemap;

    public Transform spawnTowerRoot;

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn())
        {
            DetectSpawnPoint();
        }
    }

    private bool CanSpawn()
    {
        if (spawnID == -1)
            return false;
        else
            return true;
    }

    private void DetectSpawnPoint()
    {
        // Dectec the mouse clicking
        if (Input.GetMouseButtonDown(0))
        {
            // Get the world space position of the mouse
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get the position of the cell in the tilemap
            //Vector2 cellPos = spawnTilemap.LocalToWorld(mousePos);
            var cellPos = spawnTilemap.WorldToCell(mousePos);
            Debug.Log(cellPos);

            // Get the center position of the cell
            Vector2 cellPosCenter = spawnTilemap.GetCellCenterWorld(cellPos);
            //var cellPosCenter = spawnTilemap.GetCellCenterWorld(cellPos);


            // Check if the postion has collider which mean it is correct positions to place towers
            // If the collider type is sprite, it means to have a collider
            if (spawnTilemap.GetColliderType(cellPos) == Tile.ColliderType.Sprite)
            {
                // Place it in the center of the selected cell
                // test.transform.position = cellPosCenter; // I comment this line

                // Get the currency of the tower that is going to be spawn in order to check if there is enough to proceed
                int towerCost = towerPrefabs[spawnID].GetComponent<Tower>().cost;
                // Check if the current currency permits to spawn a new Tower. Calling CurrencySystem script to get currency
                if (GameManager.instance.currency.EnoughCurrency() >= towerCost)
                {
                    // Use the amount of cost from the currency available
                    GameManager.instance.currency.Use(towerCost);
                    // Spawn the tower
                    SpawnTower(cellPosCenter);
                    // Then disable the collider
                    spawnTilemap.SetColliderType(cellPos, Tile.ColliderType.None);
                }
                else 
                { Debug.Log("Not enough currency"); }
                


                // test.enabled = true; // I comment this line
            }
            //else
            //{
            //    test.enabled = false;
            //    spawnTilemap.SetColliderType(cellPos, Tile.ColliderType.Sprite);
            //}

        }

    }
    void SpawnTower(Vector3 position) 
    {
        GameObject tower = Instantiate(towerPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;
        DeselectTower();
    }
    public void SelectTower(int id)
    {
        DeselectTower();

        spawnID = id;
        // Highlight the tower
        towersUI[spawnID].color = Color.white;

    }
    public void DeselectTower()
    {
        // To reset the spawn ID to -1
        spawnID = -1;
        foreach (var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

}

