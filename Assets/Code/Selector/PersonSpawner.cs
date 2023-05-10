using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class PersonSpawner : MonoBehaviour
    {
        [SerializeField] private Transform personsParent;

        [SerializeField] private PersonSpawnerSettings settings;

        public List<Person> Persons;

        private PersonFactory personFactory;
        private PersonService personService;
        public void Init(PersonFactory personFactory, PersonService personService)
        {
            this.personFactory = personFactory;
            this.personService = personService;
        }

        public void SpawnPersons()
        {

            if (Persons == null)
                Persons = new List<Person>();

            var personsData = personService.GetRecords();

            int totalDataCount = personsData.Count;

            for (int i = 0; i < totalDataCount; i++)
            {
                int xCount =  i % (int)settings.MaxConstraints.x;
                int yCount = (int)(i / settings.MaxConstraints.x);

                Vector3 position = new Vector3(xCount * settings.Step.x, yCount * settings.Step.y, 0);
                Person person = personFactory.CreatePerson(personsParent, position);
                person.DrawPerson(personsData[i]);

                Persons.Add(person);
            }
        }

        public void DestroyPersons()
        {
            if(Persons.Count > 0)
            {
                for (int i = Persons.Count - 1; i >=0; i--)
                {
                    Destroy(Persons[i]);
                }
            }
        }
    }

    [System.Serializable]
    public class PersonSpawnerSettings
    {
        public Vector2 MaxConstraints;
        public Vector2 Step;
    }
}