using System.Collections;
using System.Collections.Generic;

public interface IItems
{
    string ID { get; }
    string Name { get; }    
    int Price { get; }
    string Rarity {  get; }
    string Type { get; }

}
