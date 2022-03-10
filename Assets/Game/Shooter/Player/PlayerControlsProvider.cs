using System.Collections;
using UnityEngine;

public class PlayerControlsProvider
{
    private static PlayerControls controls;

    public static PlayerControls Get()
    {
        if (controls == null)
            controls = new PlayerControls();

        return controls;
    }
}