﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerInput : MonoBehaviour
{
    public enum PlayerId
    {
        none = 0,
        pad_1 = 1,
        pad_2 = 2,
        pad_3 = 3,
        pad_4 = 4,
        keyboard_1 = 5,
        keyboard_2 = 6,
        test = 7
    }
    public enum InputActions
    {
        Vertical = 0,
        Horizontal = 1,
        RightVertical = 2,
        RightHorizontal = 3,
        Attack = 4,
        Cancel = 5,
        Menu = 6
    }

    [SerializeField]
    private PlayerId playerId = PlayerId.none;

    private Player RewiredPlayer { get { return ReInput.players.GetPlayer((int)playerId - 1); } }

    public bool GetButtonDown(InputActions input)
    {
        return RewiredPlayer.GetButtonDown(input.ToString());
    }

    public bool GetButtonUp(InputActions input)
    {
        return RewiredPlayer.GetButtonUp(input.ToString());
    }

    public bool GetButton(InputActions input)
    {
        return RewiredPlayer.GetButton(input.ToString());
    }

    public float GetAxis(InputActions input)
    {
        return RewiredPlayer.GetAxis(input.ToString());
    }
}