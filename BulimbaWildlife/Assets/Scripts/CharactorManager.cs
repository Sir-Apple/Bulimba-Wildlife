using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorManager : MonoBehaviour
{
    public static CharactorManager Instance;

    public GameObject ibis;
    public GameObject other;

    private Transform currentTransform;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitialiseCharactor();
    }

    public GlobalParameters.Charactors GetCurrentCharactor()
    {
        return GlobalParameters.currentCharactor;
    }

    public void InitialiseCharactor()
    {
        switch (GetCurrentCharactor())
        {
            case GlobalParameters.Charactors.ibis:
                ChooseIbis();
                break;
            case GlobalParameters.Charactors.other:
                ChooseOther();
                break;
            case GlobalParameters.Charactors.none:

                break;
            default:
                break;
        }
    }

    public Transform GetCurrentCharactorTransform()
    {
        return currentTransform;
    }

    private void SetCurrentCharactorTransform(Transform curTrans)
    {
        currentTransform = curTrans;
    }

    private void ChooseIbis()
    {
        ibis.SetActive(true);
        other.SetActive(false);

        SetCurrentCharactorTransform(ibis.transform);
    }

    private void ChooseOther()
    {
        other.SetActive(true);
        ibis.SetActive(false);
        SetCurrentCharactorTransform(other.transform);
    }
    
}
