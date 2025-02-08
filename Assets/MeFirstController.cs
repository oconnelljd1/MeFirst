using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeFirstController : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] Transform _playerHolder;

    private List<Player> _players = new List<Player>();

    private int _playerIndex = 0;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void NewPlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _playerHolder);
        Player newPlayer = player.GetComponent<Player>();
        newPlayer.Init(this, _playerIndex);
        _players.Add(newPlayer);

        _playerIndex++;
    }

    public void NextPlayer()
    {
        _playerHolder.GetChild(0).SetAsLastSibling();
    }

    public void PreviousPlayer()
    {
        _playerHolder.GetChild(_playerHolder.childCount - 1).SetAsFirstSibling();
    }

    public void Sort()
    {
        List<Player> sortedPlayers = _players.ToList();
        sortedPlayers.Sort((a, b) => b.Initiative - a.Initiative);

        for(int i = 0; i < sortedPlayers.Count; i++)
        {
            sortedPlayers[i].transform.SetSiblingIndex(i);
        }

        PreviousPlayer();
    }

    public void Delete(int id)
    {
        
        Player toDelete = _players.Find(p=>p.Id == id);
        _players.Remove(toDelete);
        Destroy(toDelete.gameObject);
    }
}
