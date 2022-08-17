using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant", order = 1)]
public class Plant : ScriptableObject
{
    public string plantName = "New Plant";
    public int plantType = -1;      // 0 - tall, 1 - stout/long
    public float growTime = 0f;
    public Sprite stage1 = null;
    public Sprite stage2 = null;
    public Sprite stage3 = null;
    public Sprite stage4 = null;

}
