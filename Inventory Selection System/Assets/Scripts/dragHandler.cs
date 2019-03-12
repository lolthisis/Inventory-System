using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragHandler : MonoBehaviour
{
    equippedItemHandller eIH;

    public itemHandler myItem;
    // Start is called before the first frame update
    void Start()
    {
        eIH = FindObjectOfType<equippedItemHandller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(destroy());
        }

        this.transform.localPosition = new Vector3(Input.mousePosition.x - Screen.width / 2f, Input.mousePosition.y - Screen.height / 2f, 0f);
    }

    bool triggering;

    private void OnTriggerStay2D(Collider2D collision)
    {
        triggering = true;
        if (Input.GetMouseButtonUp(0))
        {
            if (this.GetComponent<itemHandler>().itemSlot == collision.gameObject.GetComponent<slotHandler>().iSlot)
            {
                eIH.itemDropped(myItem,collision.gameObject.GetComponent<slotHandler>().iSlot, collision.gameObject.GetComponent<slotHandler>().weaponSlot);
            }
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggering = false;
    }
}
