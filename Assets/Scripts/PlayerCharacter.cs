using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RedHeadToolz.Screens;

namespace MeFirst
{
    public class PlayerCharacter : Character
    {
        public string PlayerName => _playerDisplay.text;

        [SerializeField] private TMP_Text _playerDisplay;

        public PlayerCharacter Init(MeFirstController controller, int id)
        {
            base.Init(controller, id);

            return this;
        }

        public void UpdateDisplay(string character, string player, string initiative, string ac)
        {
            _playerDisplay.text = player;

            base.UpdateDisplay(character, initiative, ac);
        }

        public virtual void OnEdit()
        {
            ScreenManager.Instance.AddScreen<PlayerCharacterScreen>()
                .Init(this)
                .Show();
        }
    }
}