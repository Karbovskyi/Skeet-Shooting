using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkeetShootingMediator : MonoBehaviour
{
    [SerializeField] private GameObject _shootButton;
    private IThrowableObjectShootService _shootService;

    public void Initialize(IThrowableObjectShootService shootService)
    {
        _shootService = shootService;
    }
    
    public void Shoot() => _shootService.Shoot();
    public void ActivateShootButton() => _shootButton.SetActive(true);
    public void DeactivateShootButton() => _shootButton.SetActive(false);


}
