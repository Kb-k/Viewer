using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum GizmoMode
{
    Translate = 0,
    Rotate = 1,
    Scale = 2
}

/// <summary>
/// Transform manipulation gizmo for a selected transform.
/// </summary>
public class TransformGizmo : MonoBehaviour
{
    [SerializeField]
    private GameObject _gizmosParent;

    [SerializeField]
    private ModeGizmo _translateGizmo;

    [SerializeField]
    private ModeGizmo _rotateGizmo;

    [SerializeField]
    private ModeGizmo _scaleGizmo;

    [SerializeField]
    private UnityEvent _translateModeSelected;

    [SerializeField]
    private UnityEvent _rotateModeSelected;

    [SerializeField]
    private UnityEvent _scaleModeSelected;

    private GizmoMode _currentMode;
    private Transform _selectedTransform;
    private EventSystem _eventSystem;

    public Transform SelectedTransform
    {
        get { return _selectedTransform; }
        set { _selectedTransform = value; }
    }

    public GizmoMode CurrentMode
    {
        get { return _currentMode; }
    }

    public UnityEvent OnTranslateModeSelected
    {
        get { return _translateModeSelected; }
    }

    public UnityEvent OnRotateModeSelected
    {
        get { return _rotateModeSelected; }
    }

    public UnityEvent OnScaleModeSelected
    {
        get { return _scaleModeSelected; }
    }

	private void Start ()
    {
	}
	
	private void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            SetGizmoMode(GizmoMode.Translate);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetGizmoMode(GizmoMode.Rotate);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetGizmoMode(GizmoMode.Scale);
        }
	}

    public void SetGizmoMode(GizmoMode mode)
    {
        _currentMode = mode;
        switch (_currentMode)
        {
            case GizmoMode.Translate:
                _translateGizmo.ShowGizmo(true);
                _rotateGizmo.ShowGizmo(false);
                _scaleGizmo.ShowGizmo(false);
                _translateModeSelected.Invoke();
                break;
            case GizmoMode.Rotate:
                _translateGizmo.ShowGizmo(false);
                _rotateGizmo.ShowGizmo(true);
                _scaleGizmo.ShowGizmo(false);
                _rotateModeSelected.Invoke();
                break;
            case GizmoMode.Scale:
                _translateGizmo.ShowGizmo(false);
                _rotateGizmo.ShowGizmo(false);
                _scaleGizmo.ShowGizmo(true);
                _scaleModeSelected.Invoke();
                break;
        }
    }

    public void SelectTransform(GameObject selectedGO)
    {
        SelectTransform(selectedGO.transform);
    }

    public void SelectTransform(Transform selected)
    {
        _selectedTransform = selected;
        transform.position = selected.position;
        ShowGizmos(true);
        Debug.Log("Set selected: " + selected.name);
    }

    public void DeselectTransform()
    {
        _selectedTransform = null;
        ShowGizmos(false);
    }

    private void ShowGizmos(bool show)
    {
        _gizmosParent.SetActive(show);
    }
}
