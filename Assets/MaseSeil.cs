using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaseSeil : MonoBehaviour
{

    [SerializeField] private GameObject _leftwall;
    [SerializeField] private GameObject _rightwall;
    [SerializeField] private GameObject _frontwall;
    [SerializeField] private GameObject _behindwall;
    [SerializeField] private GameObject _floor;

    [SerializeField] private GameObject _invisitedBlock;

    public bool Isvisited { get; private set; }

    public void visit()
    {
        Isvisited = true;
        _invisitedBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftwall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightwall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        _frontwall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _behindwall.SetActive(false);
    }

    public void SetScale(Vector3 scale)
    {
        
        _floor.transform.localScale = scale;
    }
}

