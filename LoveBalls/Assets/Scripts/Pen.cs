using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pen", menuName = "Pen")]
public class Pen : ScriptableObject {

    public new string name;
    public int price;
    public Sprite penSprite;
}
