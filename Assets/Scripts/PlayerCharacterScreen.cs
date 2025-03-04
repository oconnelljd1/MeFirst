using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedHeadToolz.Screens;
using TMPro;

namespace MeFirst
{
    public class PlayerCharacterScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _characterInput;
        [SerializeField] private TMP_InputField _playerInput;
        [SerializeField] private TMP_InputField _initiativeInput;
        [SerializeField] private TMP_InputField _acInput;

        private PlayerCharacter _character;

        public PlayerCharacterScreen Init(PlayerCharacter character)
        {
            _character = character;

            _characterInput.text = _character.CharacterName;
            _playerInput.text = _character.PlayerName;
            _initiativeInput.text = _character.Initiative.ToString();
            _acInput.text = _character.AC;

            return this;
        }

        public void UpdateCharacter()
        {
            _character.UpdateDisplay(_characterInput.text, _playerInput.text, _initiativeInput.text, _acInput.text);
        }

        public void OnDone()
        {
            UpdateCharacter();
            Close();
        }

        public void OnDelete()
        {
            _character.Delete();
            Close();
        }
    }
}
