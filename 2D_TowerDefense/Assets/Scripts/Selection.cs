using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Selection : MonoBehaviour
{
    public Tilemap tileMap;
    //public Tile tile;
    //public TileBase tileb;
    //public Transform highlight;
    public Transform hi;
    //public BoxCollider2D aCollider;

    //public List<Transform> wTiles = new List<Transform>();
 
    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<Tilemap>();
        //aCollider = hi.GetComponent<BoxCollider2D>();
        //highlight = GetComponentInChildren<Transform>();

        //int i = 0;
        //for (float x = -7.66f; x < 7.9; x=x+1.4f)
        //{
        //    for (float y = -3.5f; y < 2.1; y=y+1.4f)
        //    {

        //        Transform  tr = Instantiate(highlight);
        //        //GameObject ha = h.gameObject;
        //        //TilemapCollider2D c = ha.AddComponent<TilemapCollider2D>();
        //        //SpriteRenderer s = ha.GetComponent<SpriteRenderer>();
        //        //s.enabled = false;
        //        //c.enabled = true;
        //        wTiles.Add(tr);
        //        tr.position = new Vector2(x, y);
        //        //wTiles[i].tr = Instantiate(highlight);
        //        GameObject go = tr.gameObject;
        //        TilemapCollider2D tco = go.AddComponent<TilemapCollider2D>();
        //        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();

        //        //sr.enabled = false;
        //        tco.enabled = true;

        //        tr.tag = "highlight";
        //        i++;
        //    }  
        //}

    }

    // Update is called once per frame
    void Update()
    {
        // Get the world space position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //hi.position = mousePos;
        // Get the position of the cell in the tilemap
        //Vector2 cellPos = tileMap.LocalToWorld(mousePos);

        var cellPos = tileMap.WorldToCell(mousePos);
        Vector2 cellPosCenter = tileMap.GetCellCenterWorld(cellPos);
        hi.position = cellPosCenter;

        //Vector3Int cellPos = tileMap.WorldToCell(mousePos);
        //tile = (Tile)tileMap.GetTile(cellPos);
        //Color rs = tile.color;
        //TileBase tileb = tileMap.GetTile(cellPos);
    }

    private void OnMouseEnter()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(Input.mousePosition, Vector3.forward, out hit, 900f))
        //{
        //    Debug.Log("NO"+hit.transform.name);
        //} 

        //Debug.Log("yes"+tile);

        //tile.color = Color.blue;
        //tile.gameObject.SetActive(false);

        //if (tile != null)
        //{
        //    SpriteRenderer srr = tile.gameObject.GetComponent<SpriteRenderer>();
        //    srr.color = Color.blue;
        //}
    }

    private void OnMouseExit()
    {
        //tile.color = Color.white;
    }
}
