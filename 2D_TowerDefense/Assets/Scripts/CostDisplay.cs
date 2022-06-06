using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CostDisplay : MonoBehaviour
{
    public int towerID;
    public int towerCost;

    // Start is called before the first frame update
    void Start()
    {
        towerCost = GameManager.instance.spawner.TowerCost(towerID);
        GetComponent<UnityEngine.UI.Text>().text = towerCost.ToString();
    }

}
