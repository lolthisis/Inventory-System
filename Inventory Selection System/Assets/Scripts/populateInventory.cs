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

    [SerializeField]
    filtersHandler fH;

    selectedItemHandler sIH;
    // Start is called before the first frame update
    void Start()
    {
        sIH = FindObjectOfType<selectedItemHandler>();
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
        StartCoroutine(selectFirst());
        fH.filterT();
    }

    IEnumerator selectFirst()
    {
        yield return new WaitForSeconds(0.75f);
        sIH.itemSelected(items[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
