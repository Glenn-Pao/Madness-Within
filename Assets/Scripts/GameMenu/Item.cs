using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{

    bool isTrigger = false;
    int shootWaitTime = 0;

    public enum ItemType
    {
        // If you wanna add new ItemType, please to last.

        EMPTY,
        GUN,
        SWORD,

    }
    public ItemType _itemType;

    // Use this for initialization
    void Start()
    {
        switch (_itemType)
        {
            case ItemType.GUN:
                break;
            case ItemType.SWORD:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (_itemType)
        {
            case ItemType.GUN:
                if (shootWaitTime >= 90)
                {
                    isTrigger = false;
                    Debug.Log(isTrigger);
                }

                shootWaitTime++;
                              
                break;
            case ItemType.SWORD:
                break;
        }
      
    }

    public void UseItem()
    {
        switch (_itemType)
        {
            case ItemType.GUN:
                shoot();
                break;
            case ItemType.SWORD:
                break;
        }
    }

    void shoot()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.AddComponent<Bullet>();
        obj.tag = "Bullet";
        obj.transform.position = GameObject.Find("RightHand").transform.position + GameObject.Find("RightHand").transform.forward + GameObject.Find("RightHand").transform.right / 10;
        //obj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
        obj.transform.rotation = Camera.main.transform.rotation;
        obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        isTrigger = true;
        shootWaitTime = 0;
    }
}
