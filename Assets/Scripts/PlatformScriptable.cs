using UnityEngine;

[CreateAssetMenu(fileName = "Platform", menuName = "New Platform")]
public class PlatformScriptable : ScriptableObject
{
    [field: SerializeField]
    public Color PlatformColor { get; private set; }

    [field: SerializeField]
    public float JumpForce { get; private set; }

    [field: SerializeField]
    public bool IsBreakable { get; private set; }

    [field: SerializeField]
    public float MovingSpeed { get; private set; }
}
