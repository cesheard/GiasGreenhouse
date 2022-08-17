using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public abstract class Plant : ScriptableObject
{
    public string plantName = "New Plant";
    public Sprite stage1 = null;
    public Sprite stage2 = null;
    public Sprite stage3 = null;
    public Sprite stage4 = null;
    public float growTime = 0.0f;

}
