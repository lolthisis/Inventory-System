using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectedItemHandler : MonoBehaviour
{
    [SerializeField]
    ItemConfig ic;

    [SerializeField]
    Text equip,damage,str,agi,intel,defense,discription,name,rarityClass;

    [SerializeField]
    Image icon;

    [SerializeField]
    equippedItemHandller eIH;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentItem)
        {
            if (currentItem.equiped)
                equip.text = "Unequip";
            else
                equip.text = "Equip";
        }
    }

    itemHandler currentItem;
    public void itemSelected(itemHandler item)
    {
        eIH.itemSelected(item);
        currentItem = item;
        if (item.equiped)
            equip.text = "Unequip";
        else
            equip.text = "Equip";

        damage.text = "" + ic.items[item.itemNo].damage;
        str.text = "" + ic.items[item.itemNo].strength;
        agi.text = "" + ic.items[item.itemNo].agility;
        intel.text = "" + ic.items[item.itemNo].intel;
        defense.text = "" + ic.items[item.itemNo].defence;

        icon.sprite = ic.items[item.itemNo].icon;
        name.text = ic.items[item.itemNo].item_name;
        discription.text = ic.items[item.itemNo].description;
        rarityClass.text = "" + ic.items[item.itemNo].item_class;
    }

    public void equipItem()
    {
        eIH.itemEquipped(currentItem);
        currentItem.equiped = !currentItem.equiped;
    }

}
