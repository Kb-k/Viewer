using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// FOr objects which provide a method for selecting a gameobject.
/// </summary>
internal interface IObjectSelector
{
    GameObject SelectedObject { get; }

    SelectEvent OnObjectSelected { get; }
}