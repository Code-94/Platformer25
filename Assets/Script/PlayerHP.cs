using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public Slider _slider;

    public PlayerMove _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetMaxHp(_slider.maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (_slider.value == 0)
        {
            Destroy(_player.gameObject);
        }
    }
    
    public void SetMaxHp(float Hp)
    {
        _slider.maxValue = Hp;
        _slider.value = Hp;
    }
}
