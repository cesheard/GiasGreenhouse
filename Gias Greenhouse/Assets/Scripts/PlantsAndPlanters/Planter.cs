using UnityEngine;

[CreateAssetMenu(fileName = "New Planter", menuName = "Planter", order = 1)]
public class Planter : ScriptableObject
{
    public string planterName = "New Planter";
    public int planterType = -1;  // 0 - clay pot, 1 - long planter
    public Sprite planterSprite;

}
