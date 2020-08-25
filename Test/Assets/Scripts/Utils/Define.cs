using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum MouseEvent
    {
        Press,
        Click
    }
    public enum CamMode
    {
        QuarterView,
        PersonalView
    }

    public enum UiEvent
    {
        Click,
        Drag,
    }

    public enum Scenes
    {
        Unknown,
        Login,
        Lobby,
        Game,
        NewGame,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,

    }
}
