using UnityEngine;

namespace aprilJam
{
  [CreateAssetMenu(fileName = "ButtonPalette", menuName = "aprilJam/ButtonPalette")]
  public class ButtonPalette : ScriptableObject
  {
    public Color normal;
    public Color active;
    public Color pressed;
  }
}
