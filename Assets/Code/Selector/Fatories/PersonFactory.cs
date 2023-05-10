using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class PersonFactory
    {
        private PersonFactorySettings settings;
        
        public PersonFactory(PersonFactorySettings settings)
        {
            this.settings = settings;
        }

        public Person CreatePerson(Transform parent, Vector3 position,
                                    PersonTypes personType = PersonTypes.Default)
        {
            switch (personType)
            {
                default:
                    return GameObject.Instantiate(settings.DefaultPersonPrefab,position, Quaternion.identity, parent);
            }
        }
    }

    public enum PersonTypes
    {
        Default,
        //maybe artist, programmer ets
    }

    [System.Serializable]
    public class PersonFactorySettings
    {
        public Person DefaultPersonPrefab;
    }

    //public class PersonFactorySettings
    //{
    //    public List<PersonTypesListElement> PersonsType;
    //}

    //[System.Serializable]
    //public class PersonTypesListElement
    //{
    //    public PersonTypes PersonType;
    //    public Person PersonPrefab;
    //}
}