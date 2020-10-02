using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Head : MonoBehaviour {

    Vector2 direction = Vector2.right;

    void Start() {
        InvokeRepeating("Move", 0.2f, 0.2f);
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
        transform.Translate(direction);
    }
}
