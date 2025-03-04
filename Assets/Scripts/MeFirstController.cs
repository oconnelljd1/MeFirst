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
        [SerializeField] GameObject _enemyPrefab;
        [SerializeField] Transform _characterHolder;

        private List<Character> _characters = new List<Character>();

        private int _characterIndex = 0;

        void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.orientation = ScreenOrientation.Portrait;
        }

        public void OnNew()
        {
            GenericScreenData screenData = new GenericScreenData
            {
                Title = "New Character",
                Description = "",
                Buttons = new List<GenericButtonData>
                {
                    new GenericButtonData
                    {
                        Text = "Player Character",
                        OnClick = NewPlayerCharacter
                    },
                    new GenericButtonData
                    {
                        Text = "Enemy",
                        OnClick = NewEnemy
                    }
                }
            };
            ScreenManager.Instance.AddScreen<GenericScreen>()
                .Setup(screenData)
                .Show();
        }

        public void NewPlayerCharacter()
        {
            PlayerCharacter character = Instantiate(_characterPrefab, _characterHolder)
                .GetComponent<PlayerCharacter>()
                .Init(this, _characterIndex);
            _characters.Add(character);

            ScreenManager.Instance.AddScreen<PlayerCharacterScreen>()
                .Init(character)
                .Show();

            _characterIndex++;
            ScreenManager.Instance.CloseScreen<GenericScreen>();
        }

        public void NewEnemy()
        {
            Enemy newCharacter = Instantiate(_enemyPrefab, _characterHolder)
                .GetComponent<Enemy>()
                .Init(this, _characterIndex);
            _characters.Add(newCharacter);

            ScreenManager.Instance.AddScreen<EnemyScreen>()
                .Init(newCharacter)
                .Show();

            _characterIndex++;
            ScreenManager.Instance.CloseScreen<GenericScreen>();
        }

        public void OnNext()
        {
            _characterHolder.GetChild(0).SetAsLastSibling();
        }

        public void OnBack()
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

            OnBack();
        }

        public void Delete(int id)
        {
            Character toDelete = _characters.Find(p => p.Id == id);
            _characters.Remove(toDelete);
            Destroy(toDelete.gameObject);
        }
    }
}
