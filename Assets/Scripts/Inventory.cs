using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    
    public static Inventory singleton;

    private void Awake()
    {
        singleton = this;
    }
    
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    public int capacity = 20;
    
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (item.isDefaultItem) return false;
        if (items.Count >= capacity) return false;

        items.Add(item);
        onItemChangedCallback?.Invoke();

        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);
        onItemChangedCallback?.Invoke();
    }
}
