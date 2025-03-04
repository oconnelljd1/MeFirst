using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RedHeadToolz.Screens;
using UnityEngine.UI;
using RedHeadToolz.Debugging;

namespace MeFirst
{
    public class Enemy : Character
    {
        public int MaxHP => _maxHP;

        [SerializeField] private TMP_Text _hpText;
        [SerializeField] private Image _hpFill;
        private int _maxHP;
        private int _currentHP;

        public Enemy Init(MeFirstController controller, int id)
        {
            base.Init(controller, id);
            return this;
        }

        public void UpdateDisplay(string character, string hp, string initiative, string ac)
        {
            int newMxHP;
            if (int.TryParse(hp, out newMxHP))
            {
                _maxHP = newMxHP;
            }
            if(_currentHP > _maxHP || _currentHP == 0)
            {
                _currentHP = _maxHP;
            }
            _hpText.text = $"{_currentHP}/{_maxHP}";
            _hpFill.fillAmount = (float)_currentHP / _maxHP;

            base.UpdateDisplay(character, initiative, ac);
        }

        public void EditHP()
        {
            RHTebug.Log("Edit HP");
        }

        public virtual void OnEdit()
        {
            ScreenManager.Instance.AddScreen<EnemyScreen>()
                .Init(this)
                .Show();
        }
    }
}