using UnityEngine;

namespace DapperDino.GettingStarted.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Damage Type", menuName = "Combat/Damage Type")]
    public class DamageType : ScriptableObject
    {
        [SerializeField] private new string name = "New Damage Type Name";
        [SerializeField] private Color colour = new Color(0f, 0f, 0f, 1f);

        public string Name => name;
        public Color Colour => colour;
    }
}