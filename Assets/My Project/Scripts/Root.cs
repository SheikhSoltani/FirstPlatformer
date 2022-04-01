using System.Collections.Generic;
using Pathfinding;
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


    [SerializeField]
    private AIConfig _simplePatrolAIConfig;

    [Header("Protector AI")]
    [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
    [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
    [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
    [SerializeField] private Transform[] _protectorWaypoints;

    private SimplePatrolAI _simplePatrolAI;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroPhysicsWalker _mainHeroWalker;

    private ProtectorAI _protectorAI;
    private ProtectedZone _protectedZone;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);

        _protectorAI = new ProtectorAI(_characterView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
        _protectorAI.Init();

        _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
        _protectedZone.Init();
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
        _protectorAI.Deinit();
        _protectedZone.Deinit();
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
