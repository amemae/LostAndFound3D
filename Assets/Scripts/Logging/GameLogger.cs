using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum LogTag
{
    AI,
    STATE_ENTER,
    STATE_EXIT,
    PATHFINDING,
    EDITOR,
    UNEXPECTED_NULL,
    COROUTINE,
    AI_MOVEMENT
}

public static class GameLogger
{
    public static void DebugLog(string message, List<LogTag> tags = null, Object context = null)
    {
        Debug.Log(ConstructLog(message, tags), context);
    }

    public static void WarnLog(string message, List<LogTag> tags = null, Object context = null)
    {
        Debug.LogWarning(ConstructLog(message, tags), context);
    }

    public static void ErrorLog(string message, List<LogTag> tags = null, Object context = null)
    {
        Debug.LogError(ConstructLog(message, tags), context);
    }

    private static string ConstructLog(string message, List<LogTag> tags = null)
    {
        StringBuilder sb = new StringBuilder();
        AppendTags(sb, tags);
        sb.Append(message);

        return sb.ToString();
    }

    private static void AppendTags(StringBuilder sb, List<LogTag> tags)
    {
        if (tags?.Count > 0)
        {
            foreach (LogTag tag in tags)
            {
                sb.Append("[");
                sb.Append(tag);
                sb.Append("]");
            }
            sb.Append(" ");
        }
    }
}
