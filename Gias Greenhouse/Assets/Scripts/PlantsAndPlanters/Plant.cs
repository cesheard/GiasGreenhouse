using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant", order = 1)]
public class Plant : ScriptableObject
{
    public string plantName = "New Plant";
    public Sprite[] stages = new Sprite[4];

}
