using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLayerPresenter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject mobileLayer;

    private void Awake()
    {
#if UNITY_ANDROID
        this.mobileLayer.SetActive(true);
#endif
    }
}
