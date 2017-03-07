using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFormatAttribute : PropertyAttribute {

    public readonly bool DisplayHours;

    public TimeFormatAttribute(bool displayHours)
    {
        this.DisplayHours = displayHours;
    }
}
