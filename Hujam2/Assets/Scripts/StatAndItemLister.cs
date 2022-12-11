using Assets.Entity;
using Assets.Entity.Items;
using Assets.Entity.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAndItemLister : MonoBehaviour
{
    public List<EventItem> allItems;
    public List<ShipStats> allStats;
    private AllItems itemScript;
    private AllStats statScript;

    public StatAndItemLister()
    {
        
        itemScript = new AllItems();
        statScript = new AllStats();
        allItems = new List<EventItem>();
        allStats = new List<ShipStats>();
        allItems = itemScript.getAllItems();
        Debug.Log("StatItemLister2 " + allItems.Count);
        allStats = statScript.getAllShipStats();
    }
    void Awake()
    {
        Debug.Log("StatItemLister AWAKE");

    }

   
    
}
