using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RedHeadToolz.Screens;

namespace MeFirst
{
    public class Character : MonoBehaviour
    {
        public int Id => _id;
        public int Initiative => _initiative;
        public string CharacterName => _characterDisplay.text;
        public string AC => _acDisplay.text;

        [SerializeField] private TMP_Text _characterDisplay;
        [SerializeField] private TMP_Text _acDisplay;
        [SerializeField] private TMP_Text _initiativeDisplay;
        private MeFirstController _controller;
        protected int _id;
        private int _initiative;

        public Character Init(MeFirstController controller, int id)
        {
            _controller = controller;
            _id = id;

            return this;
        }

        public virtual void UpdateDisplay(string character, string initiative, string ac)
        {
            _characterDisplay.text = character;
            _initiativeDisplay.text = initiative;
            _acDisplay.text = ac;

            UpdateInitiative();
        }

        public virtual void UpdateInitiative()
        {
            int newInitiative;
            if (int.TryParse(_initiativeDisplay.text, out newInitiative))
            {
                _initiative = newInitiative;
            }
            _controller.Sort();
        }

        public virtual void Delete()
        {
            _controller.Delete(_id);
        }
    }
}