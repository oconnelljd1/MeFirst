using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int Id => _id;
    public int Initiative => _initiative;
    [SerializeField] private TMP_InputField _initiativeInput;
    private MeFirstController _controller;
    private int _id;
    private int _initiative;

    public void Init(MeFirstController controller, int id)
    {
        _controller = controller;
        _id = id;
    }

    public void UpdateInitiative()
    {
        int newInitiative;
        if(int.TryParse(_initiativeInput.text, out newInitiative))
        {
            _initiative = newInitiative;
        }
        _controller.Sort();
    }

    public void Delete()
    {
        _controller.Delete(_id);
    }
}
