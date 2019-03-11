using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class populateInventory : MonoBehaviour
{
    [SerializeField]
    ItemConfig ic;

    [SerializeField]
    GameObject container, itemPrefab;

    public List<itemHandler> items;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<itemHandler>();
        populate();
    }

    void populate()
    {
        //Destroy existing
        for(int i = 0; i < container.transform.childCount; i++)
        {
            Destroy(container.transform.GetChild(i).gameObject);
        }
        //Populate
        for (int i = 0; i < ic.items.Count; i++)
        {
            GameObject obj= GameObject.Instantiate(itemPrefab);
            obj.transform.SetParent(container.transform);
            obj.GetComponent<itemHandler>().initialize(i);
            items.Add(obj.GetComponent<itemHandler>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
