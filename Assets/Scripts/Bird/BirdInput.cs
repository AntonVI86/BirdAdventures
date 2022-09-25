using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdAttacker))]
public class BirdInput : MonoBehaviour
{
    private BirdMover _mover;
    private BirdAttacker _attacker;
    private Camera _camera;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Awake()
    {
        _camera = Camera.main;
        _mover = GetComponent<BirdMover>();
        _attacker = GetComponent<BirdAttacker>();
    }

    private void Update()
    {
        LimitMovement();

        if (Input.GetMouseButtonDown(0))
        {
            _attacker.CreateBullet();
        }
        else
        {
            _mover.Fly(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
        }
    }

    private void LimitMovement()
    {
        float minX = -7;
        float maxX = 7;
        float maxY = 4.7f;

        if (transform.position.x <= minX)
            transform.position = new Vector2(minX, transform.position.y);
        else if (transform.position.x >= maxX)
            transform.position = new Vector2(maxX, transform.position.y);
        if (transform.position.y >= maxY)
            transform.position = new Vector2(transform.position.x, maxY);
    }
}
