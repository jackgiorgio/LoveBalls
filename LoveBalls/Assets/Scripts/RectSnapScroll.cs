using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(ScrollRect))]
public class RectSnapScroll : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [Tooltip("Set starting page index - starting from 0")]
    public int startingPage = 0;
    [Tooltip("Threshold time for fast swipe in seconds")]
    public float fastSwipeThresholdTime = 0.3f;
    [Tooltip("Threshold time for fast swipe in (unscaled) pixels")]
    public int fastSwipeThresholdDistance = 100;
    [Tooltip("How fast will page lerp to target position")]
    public float decelerationRate = 10f;

    public Button itemStateButton;

    // fast swipes should be fast and short. If too long, then it is not fast swipe
    private int _fastSwipeThresholdMaxLimit;

    private ScrollRect _scrollRectComponent;
    private RectTransform _scrollRectRect;
    private RectTransform _container;


    // number of pages in container
    private int _pageCount;
    private int _currentPage;
    private int childWidth;

    // whether lerping is in progress and target lerp position
    private bool _lerp;
    private Vector2 _lerpTo;

    // target position of every page
    private List<Vector2> _pagePositions = new List<Vector2>();

    // in draggging, when dragging started and where it started
    private bool _dragging;
    private float _timeStamp;
    private Vector2 _startPosition;

    // for showing small page icons
    private bool _showPageSelection;
    private int _previousPageSelectionIndex;


    //------------------------------------------------------------------------
    void Start()
    {
        _scrollRectComponent = GetComponent<ScrollRect>();
        _scrollRectRect = GetComponent<RectTransform>();
        _container = _scrollRectComponent.content;
        _pageCount = _container.childCount;

        _lerp = false;

        // init
        SetPagePositions();
        SetPage(startingPage);
        LerpToPage(0);



    }
    


    //------------------------------------------------------------------------
    void Update()
    {
        // if moving to target position
        if (_lerp)
        {
            // prevent overshooting with values greater than 1
            float decelerate = Mathf.Min(decelerationRate * Time.deltaTime, 1f);
            _container.anchoredPosition = Vector2.Lerp(_container.anchoredPosition, _lerpTo, decelerate);
            // time to stop lerping?
            if (Vector2.SqrMagnitude(_container.anchoredPosition - _lerpTo) < 0.25f)
            {
                // snap to target and stop lerping
                _container.anchoredPosition = _lerpTo;
                _lerp = false;
                // clear also any scrollrect move that may interfere with our lerping
                _scrollRectComponent.velocity = Vector2.zero;
            }

        }
    }

    //------------------------------------------------------------------------
    private void SetPagePositions()
    {
        int width = 0;
        int offsetX = 0;
        int containerWidth = 0;
        int containerHeight = 0;
        int paddingSpace;

            // screen width in pixels of scrollrect window
            width = (int)_scrollRectRect.rect.width;
        paddingSpace = (int)_container.GetComponent<HorizontalOrVerticalLayoutGroup>().spacing;
            // center position of all pages
            offsetX = width/2;
        // total width
        childWidth = (int)_container.GetChild(0).GetComponent<RectTransform>().rect.width;
        containerWidth = (childWidth+paddingSpace) * _pageCount;
            // limit fast swipe length - beyond this length it is fast swipe no more
            _fastSwipeThresholdMaxLimit = childWidth;


        // set width of container
        Vector2 newSize = new Vector2(containerWidth, containerHeight);
        _container.sizeDelta = newSize;
        Vector2 newPosition = new Vector2(0, 0);
        _container.anchoredPosition = newPosition+ new Vector2(childWidth/2,0);

        // delete any previous settings
        _pagePositions.Clear();

        // iterate through all container childern and set their positions
        for (int i = 0; i < _pageCount; i++)
        {
            RectTransform child = _container.GetChild(i).GetComponent<RectTransform>();
            Vector2 childPosition;
            childPosition = new Vector2((i+1) * childWidth + paddingSpace * i - childWidth / 2, 0f);
            child.anchoredPosition = childPosition;
            _pagePositions.Add(-childPosition);
        }
    }

    //------------------------------------------------------------------------
    private void SetPage(int aPageIndex)
    {
        aPageIndex = Mathf.Clamp(aPageIndex, 0, _pageCount - 1);
        _container.anchoredPosition = _pagePositions[aPageIndex]+ new Vector2 (childWidth,0);
        _currentPage = aPageIndex;
    }

    //------------------------------------------------------------------------
    private void LerpToPage(int aPageIndex)
    {
        aPageIndex = Mathf.Clamp(aPageIndex, 0, _pageCount - 1);
        _lerpTo = _pagePositions[aPageIndex];
        _lerp = true;
        _currentPage = aPageIndex;
        IdentifyTypeOfDisplayAndDisplayUI(aPageIndex);


    }


    //------------------------------------------------------------------------
    private void NextScreen()
    {
        //Debug.Log("The Page Lerp to is " + (_currentPage+1).ToString());
        LerpToPage(_currentPage + 1);
    }

    //------------------------------------------------------------------------
    private void PreviousScreen()
    {
        LerpToPage(_currentPage - 1);
    }

    //------------------------------------------------------------------------
    private int GetNearestPage()
    {
        // based on distance from current position, find nearest page
        Vector2 currentPosition = _container.anchoredPosition;

        float distance = float.MaxValue;
        int nearestPage = _currentPage;

        for (int i = 0; i < _pagePositions.Count; i++)
        {
            float testDist = Vector2.SqrMagnitude(currentPosition - _pagePositions[i]);
            if (testDist < distance)
            {
                distance = testDist;
                nearestPage = i;
            }
        }
        return nearestPage;
    }

    //------------------------------------------------------------------------
    public void OnBeginDrag(PointerEventData aEventData)
    {
        // if currently lerping, then stop it as user is draging
        _lerp = false;
        // not dragging yet
        _dragging = false;
    }

    //------------------------------------------------------------------------
    public void OnEndDrag(PointerEventData aEventData)
    {
        // how much was container's content dragged
        float difference;
        difference = _startPosition.x - _container.anchoredPosition.x;

        // test for fast swipe - swipe that moves only +/-1 item
        if (Time.unscaledTime - _timeStamp < fastSwipeThresholdTime &&
            Mathf.Abs(difference) > fastSwipeThresholdDistance &&
            Mathf.Abs(difference) < _fastSwipeThresholdMaxLimit)
        {
            if (difference > 0)
            {
                NextScreen();
            }
            else
            {
                PreviousScreen();
            }
        }
        else
        {
            // if not fast time, look to which page we got to
            LerpToPage(GetNearestPage());
        }

        _dragging = false;
    }

    //------------------------------------------------------------------------
    public void OnDrag(PointerEventData aEventData)
    {
        if (!_dragging)
        {
            // dragging started
            _dragging = true;
            // save time - unscaled so pausing with Time.scale should not affect it
            _timeStamp = Time.unscaledTime;
            // save current position of cointainer
            _startPosition = _container.anchoredPosition;
        }
    }

    void IdentifyTypeOfDisplayAndDisplayUI(int page)
    {
        PenDisplay[] penItems = gameObject.GetComponentsInChildren<PenDisplay>();
        if (penItems.Length != 0)
        {
            Pen pen = penItems[page].pen;
            itemStateButton.GetComponent<ButtonState>().LoadButtonState(pen);
            return;
        }
        BallsDisplay[] ballsItem = gameObject.GetComponentsInChildren<BallsDisplay>();
        if (ballsItem.Length != 0)
        {
            BallSkin ballskin = ballsItem[page].ballskin;
            itemStateButton.GetComponent<ButtonState>().LoadButtonState(ballskin);
            return;
        }
        BGSkinDisplay[] bgSkins = gameObject.GetComponentsInChildren<BGSkinDisplay>();
        if (bgSkins.Length != 0)
        {
            BGSkin bgSkin= bgSkins[page].bgSkin;
            itemStateButton.GetComponent<ButtonState>().LoadButtonState(bgSkin);
            return;
        }


    }
}
