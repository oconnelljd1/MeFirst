using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RedHeadToolz.Screens;

namespace MeFirst
{
    public class MeFirstController : MonoBehaviour
    {
        [SerializeField] GameObject _characterPrefab;
        [SerializeField] Transform _characterHolder;

        private List<Character> _characters = new List<Character>();

        private int _characterIndex = 0;

        void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.orientation = ScreenOrientation.Portrait;
        }

        public void NewCharacter()
        {
            GameObject character = Instantiate(_characterPrefab, _characterHolder);
            Character newCharacter = character.GetComponent<Character>();
            newCharacter.Init(this, _characterIndex);
            _characters.Add(newCharacter);

            CharacterScreen charScreen = ScreenManager.Instance.AddScreen<CharacterScreen>();
            charScreen.Init(newCharacter);
            charScreen.Show();

            _characterIndex++;
        }

        public void NextCharacter()
        {
            _characterHolder.GetChild(0).SetAsLastSibling();
        }

        public void PreviousCharacter()
        {
            _characterHolder.GetChild(_characterHolder.childCount - 1).SetAsFirstSibling();
        }

        public void Sort()
        {
            List<Character> sortedCharacters = _characters.ToList();
            sortedCharacters.Sort((a, b) => b.Initiative - a.Initiative);

            for (int i = 0; i < sortedCharacters.Count; i++)
            {
                sortedCharacters[i].transform.SetSiblingIndex(i);
            }

            PreviousCharacter();
        }

        public void Delete(int id)
        {
            Character toDelete = _characters.Find(p => p.Id == id);
            _characters.Remove(toDelete);
            Destroy(toDelete.gameObject);
        }
    }
}
