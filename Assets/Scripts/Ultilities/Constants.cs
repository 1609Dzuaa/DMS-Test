using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants 
{
    #region CONSTANT STRINGS
    public const string PLAYER_TAG = "Player";
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string STATE_PARAM = "State";
    public const string SWORD_PARAM = "Sword";
    public const string DEAD_PARAM = "Dead";
    public const string GROUND_TAG = "Ground";
    public const string WEAPON_LAYER = "Weapon";
    #endregion

    #region CONSTANT NUMBERS
    public const float INITIAL_GRAVITY = 1.5f;
    public const float GRAVITY_WHILE_FALL = 2.7f;
    public const float FLIPABLE_OFFSET = 0.5f;
    #endregion
}
