using System.Collections;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class SelectorFactory
    {
        public SelectorFactorySettings settings;

        public SelectorFactory(SelectorFactorySettings settings)
        {
            this.settings = settings;
        }
        public ISelector GetSelector(SelectorType selectorType = SelectorType.SingleSelector)
        {
            switch (selectorType)
            {
                case SelectorType.SingleSelector:
                    return new SingleSelector();
                case SelectorType.Multiselector:
                    return new MultiSelector();
                case SelectorType.StrokeSelector:
                    return new StrokeSelector(settings.StrokeSelectorSettings);
                default:
                    return new SingleSelector();
            }
        }
    }

    public enum SelectorType
    {
        SingleSelector,
        Multiselector,
        StrokeSelector
    }

    [System.Serializable]
    public class SelectorFactorySettings
    {
        public StrokeSelectorSettings StrokeSelectorSettings;
    }
}