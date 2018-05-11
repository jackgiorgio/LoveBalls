using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "Item/penColor")]
public class PenColorPreset : ScriptableObject {

    public new string name;
    public int index;
    public Gradient colorGradient;
}
