using System;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        public string itemName;
        public string itemUseText;
        public abstract void UseItem();
    }
}