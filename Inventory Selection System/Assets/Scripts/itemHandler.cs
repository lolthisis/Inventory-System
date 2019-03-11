using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class itemHandler : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField]
    ItemConfig ic;

    public int itemNo;
    public ItemSlot itemSlot;

    [SerializeField]
    Image icon;

    [SerializeField]
    Color[] rarity;

    public int rarityNo,typeNo;
    public GameObject selected;
    public bool equiped;

    selectedItemHandler sIH;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        select();
    }

    // Start is called before the first frame update
    void Start()
    {
        sIH = FindObjectOfType<selectedItemHandler>();
    }

    public void initialize(int no)
    {
        itemSlot = ic.items[no].slot;
        itemNo = no;
        if(ic.items[no].icon)
            icon.sprite = ic.items[no].icon;

        if (ic.items[no].item_class == ItemClass.Common)
            rarityNo = 0;
        else if (ic.items[no].item_class == ItemClass.Uncommon)
            rarityNo = 1;
        else if (ic.items[no].item_class == ItemClass.Rare)
            rarityNo = 2;
        else if (ic.items[no].item_class == ItemClass.Mythical)
            rarityNo = 3;
        else if (ic.items[no].item_class == ItemClass.Legendary)
            rarityNo = 4;

        if (ic.items[no].slot == ItemSlot.Head)
            typeNo = 0;
        else if (ic.items[no].slot == ItemSlot.Body)
            typeNo = 1;
        else if (ic.items[no].slot == ItemSlot.Weapon)
            typeNo = 2;
        else if (ic.items[no].slot == ItemSlot.Feet)
            typeNo = 3;

        this.name = ic.items[no].item_name;
        this.GetComponent<RawImage>().color = rarity[rarityNo];
    }

    public void select()
    {
        sIH.itemSelected(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
