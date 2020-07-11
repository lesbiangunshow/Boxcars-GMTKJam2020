using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{
    public GameObject[] items;
    public int whichItem;
    public int timerUntilNextItem;
    void Start()
    {
        
    }
    void Update()
    {
        timerUntilNextItem -= 1;
        if (timerUntilNextItem < 0)
        {
            itemSpawn();
        }
    }
    void itemSpawn()
    {
        whichItem = Random.Range(0, 2); // choose randomly from a range which item to spawn (change 2nd range value for each item added)
        GameObject item = Instantiate(items[whichItem]); // spawn the item
        item.transform.position = transform.position; // set position of item to item shooter location
        timerUntilNextItem = Random.Range(300, 540);
    }
}
