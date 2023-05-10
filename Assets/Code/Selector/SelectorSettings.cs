using UnityEditor;
using UnityEngine;

namespace Assets.Code.Selector
{
    [CreateAssetMenu(fileName = "SelectorSettings", menuName = "ScriptableObjects/SelectorSettings", order = 1000)]

    public class SelectorSettings : ScriptableObject
    {
        public FactoriesSettings FactoriesSettings;
        public MouseKeyboardInputSettings MouseKeyboardInputSettings;
    }
}