using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Head : MonoBehaviour {

    Vector2 direction = Vector2.right;
    bool grow = false;

    [SerializeField]
    private GameObject tailPrefab;

    List<Transform> tail = new List<Transform>();

    void Start() {
        InvokeRepeating("Move", 0.1f, 0.1f);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            direction = Vector2.up;
        } else  if (Input.GetKeyDown(KeyCode.RightArrow)) {
            direction = Vector2.right;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            direction = Vector2.left;
        }
    }

    void Move() {
        Vector2 oldHeadPos = transform.position;

        transform.Translate(direction);

        if (grow) {
            GameObject newTail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            tail.Insert(0, newTail.transform);
            grow = false;
        } else if (tail.Count > 0) {
            tail.Last().position = oldHeadPos;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.StartsWith("Food")) {
            grow = true;
            Destroy(collision.gameObject);
        }
    }
}
