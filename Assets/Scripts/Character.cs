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
        public string PlayerName => _playerDisplay.text;
        public string AC => _acDisplay.text;

        [SerializeField] private TMP_Text _characterDisplay;
        [SerializeField] private TMP_Text _playerDisplay;
        [SerializeField] private TMP_Text _acDisplay;
        [SerializeField] private TMP_Text _initiativeDisplay;
        private MeFirstController _controller;
        private int _id;
        private int _initiative;

        public void Init(MeFirstController controller, int id)
        {
            _controller = controller;
            _id = id;
        }

        public void UpdateDisplay(string character, string player, string initiative, string ac)
        {
            _characterDisplay.text = character;
            _playerDisplay.text = player;
            _initiativeDisplay.text = initiative;
            _acDisplay.text = ac;

            UpdateInitiative();
        }

        public void UpdateInitiative()
        {
            int newInitiative;
            if (int.TryParse(_initiativeDisplay.text, out newInitiative))
            {
                _initiative = newInitiative;
            }
            _controller.Sort();
        }

        public void OnEdit()
        {
            CharacterScreen charScreen = ScreenManager.Instance.AddScreen<CharacterScreen>();
            charScreen.Init(this);
            charScreen.Show();
        }

        public void Delete()
        {
            _controller.Delete(_id);
        }
    }
}