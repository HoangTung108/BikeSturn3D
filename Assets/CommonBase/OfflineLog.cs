using System;
using Firebase.Analytics;

public class OfflineLog
{
    public OfflineLog(string EventName, Parameter[] Parameters)
    {
        this.EventName = EventName;
        this.Parameters = Parameters;
    }

    public string EventName;

    public Parameter[] Parameters;
}