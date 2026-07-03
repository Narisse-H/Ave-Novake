using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string item_name;
    public int item_id;
    public int item_volume;
    public int item_class;
    public string item_sprite_path;
}

[System.Serializable]
class PackageData
{
    public int package_max_volume;
    public int package_volume;
    public List<InventoryItem> items;
}

public class Player_Package : MonoBehaviour
{
    public int max_volume;
    private int volume = 0;
    [Header("List")]
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public bool Pick_up(GameObject touched_item)
    {
        Object_Info info = touched_item.GetComponent<Object_Info>();
        if (info == null)
        {
            return false;
        }
        else if ((volume + info.item_volume) > max_volume)
        {
            return false;
        }
        else
        {
            InventoryItem import = new InventoryItem
            {
                item_name = info.item_name,
                item_id = info.item_id,
                item_volume = info.item_volume,
                item_class = info.item_class,
                item_sprite_path = info.item_sprite_path
            };
            inventory.Add(import);
            volume += import.item_volume;
            Destroy(touched_item);
            return true;
        }
    }

    public bool Remove(InventoryItem rubbish)
    {
        if (inventory.Contains(rubbish))
        {
            inventory.Remove(rubbish);
            volume -= rubbish.item_volume;
            return true;
        }
        else
        {
            return false;
        }
    }

    public string Save_package()
    {
        PackageData package_data = new PackageData
        {
            package_max_volume = max_volume,
            package_volume = volume,
            items = inventory
        };
        return JsonUtility.ToJson(package_data, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
