using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerId playerId = PlayerId.none;

    Rewired.Player RewiredPlayer { get { return Rewired.ReInput.players.GetPlayer((int)playerId - 1); } }

    public PlayerId ID { get { return playerId; } }

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

public enum PlayerId
{
    none = 0,
    pad_1 = 1,
    pad_2 = 2,
    pad_3 = 3,
    pad_4 = 4,
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
