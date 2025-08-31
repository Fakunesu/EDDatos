using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IItems
{
    string ID { get; }
    string Name { get; }    
    int Price { get; }
    string Rarity {  get; }
    string Type { get; }
    
    Sprite Icon { get; }

    void AsignarSprite(ItemListSO itemImage);

}
