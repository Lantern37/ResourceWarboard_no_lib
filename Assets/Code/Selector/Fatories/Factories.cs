using System.Collections;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class Factories
    {
        public SelectorFactory SelectorFactory { get; private set; }
        public PersonFactory PersonFactory { get; private set; }

        private FactoriesSettings settings;

        public Factories(FactoriesSettings settings)
        {
            this.settings = settings;

            SelectorFactory = new SelectorFactory(settings.SelectorFactorySettings);

            PersonFactory = new PersonFactory(settings.PersonFactorySettings);
        }
    }

    [System.Serializable]
    public class FactoriesSettings
    {
        public PersonFactorySettings PersonFactorySettings;
        public SelectorFactorySettings SelectorFactorySettings;
    }
}