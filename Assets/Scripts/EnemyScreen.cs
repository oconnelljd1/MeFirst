using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedHeadToolz.Screens;
using TMPro;

namespace MeFirst
{
    public class EnemyScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _characterInput;
        [SerializeField] private TMP_InputField _hpInput;
        [SerializeField] private TMP_InputField _initiativeInput;
        [SerializeField] private TMP_InputField _acInput;

        private Enemy _character;

        public EnemyScreen Init(Enemy enemy)
        {
            _character = enemy;

            _characterInput.text = _character.CharacterName;
            _hpInput.text = _character.MaxHP.ToString();
            _initiativeInput.text = _character.Initiative.ToString();
            _acInput.text = _character.AC;

            return this;
        }

        public void UpdateCharacter()
        {
            _character.UpdateDisplay(_characterInput.text, _hpInput.text, _initiativeInput.text, _acInput.text);
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
