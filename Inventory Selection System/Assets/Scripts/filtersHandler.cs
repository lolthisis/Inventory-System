using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filtersHandler : MonoBehaviour
{
    [SerializeField]
    GameObject container;

    [SerializeField]
    GameObject[] markers;

    int currentFilter;
    // Start is called before the first frame update
    void Start()
    {
        currentFilter = -1;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < markers.Length; i++)
        {
            if (i == currentFilter)
                markers[i].SetActive(true);
            else
                markers[i].SetActive(false);
        }
    }

    public void filterT()
    {
        if (currentFilter != 0)
        {
            //Head-Body-Weapon-Feet
            for (int j = 3; j >= 0; j--)
            {
                for (int i = 0; i < container.transform.childCount; i++)
                {
                    if (container.transform.GetChild(i).GetComponent<itemHandler>().typeNo == j)
                        container.transform.GetChild(i).SetAsFirstSibling();
                }
            }
            currentFilter = 0;
        }
    }

    public void filterC()
    {

        if (currentFilter != 1)
        {
            //Common-Uncommon-Rare-Mythical-Legendary
            for (int j = 4; j >= 0; j--)
            {
                for (int i = 0; i < container.transform.childCount; i++)
                {
                    if (container.transform.GetChild(i).GetComponent<itemHandler>().rarityNo == j)
                        container.transform.GetChild(i).SetAsFirstSibling();
                }
            }
            currentFilter = 1;
        }
    }

    public void filterA()
    {
        if (currentFilter != 2)
        {
            //A-Z
            List<Transform> children = new List<Transform>();
            for (int i = container.transform.childCount - 1; i >= 0; i--)
            {
                Transform child = container.transform.GetChild(i);
                children.Add(child);
                child.parent = null;
            }
            children.Sort((Transform t1, Transform t2) => { return t1.name.CompareTo(t2.name); });
            foreach (Transform child in children)
            {
                child.parent = container.transform;
            }
            currentFilter = 2;
        }
    }

}
