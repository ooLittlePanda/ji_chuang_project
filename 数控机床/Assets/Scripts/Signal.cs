using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Signal
{
    [Header("-----Input Signal-----")]
    public static bool inputEnable = true;
    public static bool mouseEnable = true;
    public static bool keyboardEnable = true;

    [Header("-----Interact Signal-----")]
    public static bool Move = false;
    public static bool Death = false;
    public static string deathType;
    public static bool interactive = true;

    [Header("-----Stage Signal-----")]
    public static int Stage = 0;
    private static int minStage = 0;
    private static int maxStage = 1;
    private static int stageCount = 2;
    public static int[] stageComplete = new int[stageCount];

    public static int MinStage
    {
        get
        {
            return minStage;
        }
    }

    public static int MaxStage
    {
        get
        {
            return maxStage;
        }
    }

    public static int StageCount
    {
        get
        {
            return stageCount;
        }
    }
}
