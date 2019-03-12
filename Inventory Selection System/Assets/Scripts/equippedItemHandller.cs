using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class currentEquipped{
    public int currentHead, currentBody, currentFeet, currentWeapon1, currentWeapon2;
    public currentEquipped()
    {
        currentHead = currentBody = currentFeet = currentWeapon1 = currentWeapon2 = -1;
    }
    public currentEquipped(int cH,int cB,int cF,int cW1,int cW2)
    {
        currentHead = cH;
        currentBody = cB;
        currentFeet = cF;
        currentWeapon1 = cW1;
        currentWeapon2 = cW2;
    }
}

public class equippedItemHandller : MonoBehaviour
{
    [SerializeField]
    ItemConfig ic;

    [SerializeField]
    Image head, body, feet, weapon1, weapon2;

    [SerializeField]
    Text damage, str, agi, intel, defense, hp, mana, dodgeChance, critical;

    //Total
    float tdamage, tstr, tagi, tint, tdefense, thp, tmana, tdodge, tcritical;

    //Additional
    float adamage, astr, aagi, aint, adefense, ahp, amana, adodge, acritical;

    currentEquipped cE;
    string jsonString;

    [SerializeField]
    populateInventory populate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(equip());
    }

    IEnumerator equip()
    {
        //Loading
        yield return new WaitForSeconds(0.5f);
        if (File.Exists(Application.streamingAssetsPath + "/currentlyEquipped.json"))
        {
            jsonString = File.ReadAllText(Application.streamingAssetsPath + "/currentlyEquipped.json");
            cE = JsonMapper.ToObject<currentEquipped>(jsonString);
            if (cE.currentHead != -1)
                populate.items[cE.currentHead].equiped = true;
            if (cE.currentBody != -1)
                populate.items[cE.currentBody].equiped = true;
            if (cE.currentFeet != -1)
                populate.items[cE.currentFeet].equiped = true;
            if (cE.currentWeapon1 != -1)
                populate.items[cE.currentWeapon1].equiped = true;
            if (cE.currentWeapon2 != -1)
                populate.items[cE.currentWeapon2].equiped = true;
        }
        else
            cE = new currentEquipped();

        calculateStats();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void calculateStats()
    {
        tdamage = tdefense = tstr = tagi = tint = 0f;
        if (cE.currentHead != -1)
        {
            tdamage += ic.items[cE.currentHead].damage;
            tdefense += ic.items[cE.currentHead].defence;
            tstr += ic.items[cE.currentHead].strength;
            tagi += ic.items[cE.currentHead].agility;
            tint += ic.items[cE.currentHead].intel;
            head.sprite = ic.items[cE.currentHead].icon;
        }
        if (cE.currentBody != -1)
        {
            tdamage += ic.items[cE.currentBody].damage;
            tdefense += ic.items[cE.currentBody].defence;
            tstr += ic.items[cE.currentBody].strength;
            tagi += ic.items[cE.currentBody].agility;
            tint += ic.items[cE.currentBody].intel;
            body.sprite = ic.items[cE.currentBody].icon;
        }
        if (cE.currentFeet != -1)
        {
            tdamage += ic.items[cE.currentFeet].damage;
            tdefense += ic.items[cE.currentFeet].defence;
            tstr += ic.items[cE.currentFeet].strength;
            tagi += ic.items[cE.currentFeet].agility;
            tint += ic.items[cE.currentFeet].intel;
            feet.sprite = ic.items[cE.currentFeet].icon;
        }
        if (cE.currentWeapon1 != -1)
        {
            tdamage += ic.items[cE.currentWeapon1].damage;
            tdefense += ic.items[cE.currentWeapon1].defence;
            tstr += ic.items[cE.currentWeapon1].strength;
            tagi += ic.items[cE.currentWeapon1].agility;
            tint += ic.items[cE.currentWeapon1].intel;
            weapon1.sprite = ic.items[cE.currentWeapon1].icon;
        }
        if (cE.currentWeapon2 != -1)
        {
            tdamage += ic.items[cE.currentWeapon2].damage;
            tdefense += ic.items[cE.currentWeapon2].defence;
            tstr += ic.items[cE.currentWeapon2].strength;
            tagi += ic.items[cE.currentWeapon2].agility;
            tint += ic.items[cE.currentWeapon2].intel;
            weapon2.sprite = ic.items[cE.currentWeapon2].icon;
        }

        thp = tstr * 12f;
        tmana = tint * 14f;
        tdodge = tagi * 0.2f;
        tcritical = tagi * 0.15f;

        damage.text = "" + tdamage;
        defense.text = "" + tdefense;
        str.text = "" + tstr;
        intel.text = "" + tint;
        agi.text = "" + tagi;
        hp.text = "" + thp;
        mana.text = "" + tmana;
        dodgeChance.text = "" + tdodge + "%";
        critical.text = "" + tcritical + "%";


        if (head.sprite)
            head.color = Color.white;
        else
            head.color = new Color(1f, 1f, 1f, 0f);

        if (body.sprite)
            body.color = Color.white;
        else
            body.color = new Color(1f, 1f, 1f, 0f);

        if (feet.sprite)
            feet.color = Color.white;
        else
            feet.color = new Color(1f, 1f, 1f, 0f);

        if (weapon1.sprite)
            weapon1.color = Color.white;
        else
            weapon1.color = new Color(1f, 1f, 1f, 0f);

        if (weapon2.sprite)
            weapon2.color = Color.white;
        else
            weapon2.color = new Color(1f, 1f, 1f, 0f);

        if (!currentlySelected)
            return;

        int current = -1;
        if (currentlySelected.itemSlot == ItemSlot.Head)
        {
            if (cE.currentHead == currentlySelected.itemNo)
                return;
            if (cE.currentHead != -1)
                current = cE.currentHead;
            
        }
        else if (currentlySelected.itemSlot == ItemSlot.Body)
        {
            if (cE.currentBody == currentlySelected.itemNo)
                return;
            if (cE.currentBody != -1)
                current = cE.currentBody;
        }
        else if (currentlySelected.itemSlot == ItemSlot.Feet)
        {
            if (cE.currentFeet == currentlySelected.itemNo)
                return;
            if (cE.currentFeet != -1)
                current = cE.currentFeet;
        }
        else if (currentlySelected.itemSlot == ItemSlot.Weapon)
        {
            if (cE.currentWeapon1 != -1 && cE.currentWeapon2 != -1)
                current = cE.currentWeapon1;
            if (cE.currentWeapon1 == currentlySelected.itemNo)
                return;
            else if (cE.currentWeapon2 == currentlySelected.itemNo)
                return;
            else
                current = cE.currentWeapon1;
        }

        if (current == -1)
        {
            adamage = ic.items[currentlySelected.itemNo].damage;
            adefense = ic.items[currentlySelected.itemNo].defence;
            astr = ic.items[currentlySelected.itemNo].strength;
            aagi = ic.items[currentlySelected.itemNo].agility;
            aint = ic.items[currentlySelected.itemNo].intel;
        }
        else
        {
            adamage = ic.items[currentlySelected.itemNo].damage - ic.items[current].damage;
            adefense = ic.items[currentlySelected.itemNo].defence - ic.items[current].defence;
            astr = ic.items[currentlySelected.itemNo].strength - ic.items[current].strength;
            aagi = ic.items[currentlySelected.itemNo].agility - ic.items[current].agility;
            aint = ic.items[currentlySelected.itemNo].intel - ic.items[current].intel;
        }

        ahp = astr * 12f;
        amana = aint * 14f;
        adodge = aagi * 0.2f;
        acritical = aagi * 0.15f;

        damage.text += " + (" + adamage+")";
        defense.text += " + (" + adefense + ")";
        str.text += " + (" + astr + ")";
        agi.text += " + (" + aagi + ")";
        intel.text += " + (" + aint + ")";
        hp.text += " + (" + ahp + ")";
        mana.text += " + (" + amana + ")";
        dodgeChance.text += " + (" + adodge + "%)";
        critical.text += " + (" + acritical + "%)";


    }

    itemHandler currentlySelected;
    public void itemSelected(itemHandler item)
    {
        if (currentlySelected)
            currentlySelected.selected.SetActive(false);
        
        currentlySelected = item;

        currentlySelected.selected.SetActive(true);
        
        calculateStats();
    }

    public void itemEquipped(itemHandler item)
    {
        if (currentlySelected.itemSlot == ItemSlot.Head)
        {
            if (cE.currentHead == item.itemNo)
            {
                cE.currentHead = -1;
                head.sprite = null;
            }
            else
            {
                if(cE.currentHead!=-1)
                    populate.items[cE.currentHead].equiped = false;
                cE.currentHead = item.itemNo;
            }
        }
        else if (currentlySelected.itemSlot == ItemSlot.Body)
        {
            if (cE.currentBody == item.itemNo)
            {
                cE.currentBody = -1;
                body.sprite = null;
            }
            else
            {
                if (cE.currentBody != -1)
                    populate.items[cE.currentBody].equiped = false;
                cE.currentBody = item.itemNo;
            }
        }
        else if (currentlySelected.itemSlot == ItemSlot.Feet)
        {
            if (cE.currentFeet == item.itemNo)
            {
                cE.currentFeet = -1;
                feet.sprite = null;
            }
            else
            {
                if (cE.currentFeet != -1)
                    populate.items[cE.currentFeet].equiped = false;
                cE.currentFeet = item.itemNo;
            }
        }
        else if (currentlySelected.itemSlot == ItemSlot.Weapon)
        {
            if (cE.currentWeapon1 == item.itemNo)
            {
                cE.currentWeapon1 = -1;
                weapon1.sprite = null;
            }
            else if (cE.currentWeapon2 == item.itemNo)
            {
                cE.currentWeapon2 = -1;
                weapon2.sprite = null;
            }
            else if (cE.currentWeapon1 == -1)
                cE.currentWeapon1 = item.itemNo;
            else if (cE.currentWeapon2 == -1)
                cE.currentWeapon2 = item.itemNo;
            else
            {
                if (cE.currentWeapon1 != -1)
                    populate.items[cE.currentWeapon1].equiped = false;
                cE.currentWeapon1 = item.itemNo;
            }
        }

        currentlySelected = item;
        calculateStats();
    }

    public void itemDropped(itemHandler item, ItemSlot iSlot, int weaponSlot)
    {
        if (iSlot == ItemSlot.Head)
        {
            if (cE.currentHead != -1)
                populate.items[cE.currentHead].equiped = false;
            cE.currentHead = item.itemNo;
            populate.items[cE.currentHead].equiped = true;
        }
        else if (iSlot == ItemSlot.Body)
        {
            if (cE.currentBody != -1)
                populate.items[cE.currentBody].equiped = false;
            cE.currentBody = item.itemNo;
            populate.items[cE.currentBody].equiped = true;
        }
        else if (iSlot == ItemSlot.Feet)
        {
            if (cE.currentFeet != -1)
                populate.items[cE.currentFeet].equiped = false;
            cE.currentFeet = item.itemNo;
            populate.items[cE.currentFeet].equiped = true;
        }
        else if (iSlot == ItemSlot.Weapon)
        {
            if (weaponSlot == 2)
            {
                if(cE.currentWeapon1==item.itemNo)
                {
                    populate.items[cE.currentWeapon1].equiped = false;
                    cE.currentWeapon1 = -1;
                    weapon1.sprite = null;
                }
                if (cE.currentWeapon2 != -1)
                    populate.items[cE.currentWeapon2].equiped = false;
                cE.currentWeapon2 = item.itemNo;
                populate.items[cE.currentWeapon2].equiped = true;
            }
            else
            {
                if (cE.currentWeapon2 == item.itemNo)
                {
                    populate.items[cE.currentWeapon2].equiped = false;
                    cE.currentWeapon2 = -1;
                    weapon2.sprite = null;
                }
                if (cE.currentWeapon1 != -1)
                    populate.items[cE.currentWeapon1].equiped = false;
                cE.currentWeapon1 = item.itemNo;
                populate.items[cE.currentWeapon1].equiped = true;
            }
        }
        currentlySelected = item;
        calculateStats();
    }

    private void OnApplicationQuit()
    {
        //Save
        File.WriteAllText(Application.streamingAssetsPath+ "/currentlyEquipped.json", JsonMapper.ToJson(cE).ToString());
    }
}
