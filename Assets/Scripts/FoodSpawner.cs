using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject food;

    [SerializeField]
    private Transform borderTop;
    [SerializeField]
    private Transform borderBottom;
    [SerializeField]
    private Transform borderLeft;
    [SerializeField]
    private Transform borderRight;

    void Start() {
        InvokeRepeating("SpawnFood", 3, 4);
    }

    void SpawnFood() {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);

        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
