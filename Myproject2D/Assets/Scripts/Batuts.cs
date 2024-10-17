using UnityEngine;

public class Batuts : MonoBehaviour
{
    public bool isPassed { get => Platform; }
    private bool Platform = false;
    private Transform _playerTr;
    private BoxCollider2D _collider;

    public void IsPlatformTrigger()
    {
        Platform = true;
    }


    private void Start()
    {
        _playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        _collider = GetComponent<BoxCollider2D>();
    }
}
