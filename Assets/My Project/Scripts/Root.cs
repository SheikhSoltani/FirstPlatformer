using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SpriteRenderer _background;

    [SerializeField]
    private CharacterView _characterView;

    [SerializeField]
    private SpriteAnimationConfig _spriteAnimationConfig;


    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroPhysicsWalker _mainHeroWalker;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
    }

    private void FixedUpdate()
    {
        _mainHeroWalker.FixedUpdate();
    }

    private void OnDestroy()
    {

    }
    public void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
