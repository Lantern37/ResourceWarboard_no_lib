using System.Collections;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SelectorSettings selectorSettings;
        [SerializeField] private PersonService personService;
        [SerializeField] private PersonSpawner personSpawner;
        private Factories factories;
        private SelectorController selectorController;
        private InputController inputController;
        void Start()
        {
            factories = new Factories(selectorSettings.FactoriesSettings);
            inputController = new MouseKeyboardInput(selectorSettings.MouseKeyboardInputSettings);
            selectorController = new SelectorController(factories.SelectorFactory, inputController);

            personSpawner.Init(factories.PersonFactory, personService);
            selectorController.Init();
            inputController.Init();

            personSpawner.SpawnPersons();
        }

        void Update()
        {
            selectorController.Update();
            inputController.Update();
        }
    }
}