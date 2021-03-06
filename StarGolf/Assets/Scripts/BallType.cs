﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ball type")]
public class BallType : ScriptableObject {
    public Sprite[] ballSprite;
    public Sprite[] resultSprite;
    public GameObject result;
}
