using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum LoadingStep
{
    None,
    Loading,
    Selection,
    Finish
}
public class LoadingScreen : MonoBehaviour
{
    public GameObject panelLoading, panelSelectAge, buttonComplete;
    public Slider loadingProgress;
    public Text txtPre, txtNext, txtSelect, txtProgress;
    private int yearStart = 0;
    private LoadingStep _step = LoadingStep.None;
    private bool isShowOpenAds = false, isMRECLoaded = false;

    private LoadingStep step
    {
        get { return _step; }
        set
        {
            Debug.Log("Change state:" + value.ToString() + ",time:" + DateTime.Now.ToString("HH:mm:ss"));
            _step = value;
            if (value == LoadingStep.Selection)
            {
                Debug.Log("Begin start show mrec........");
                PlayerPrefs.SetInt("select_age", 1);
                AdsManager.Instance.ShowMREC();
            }
        }
    }
    private float lastIdleTime = 0;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("select_age", 0) == 1)
        {
            isMRECLoaded = true;
            loadingProgress.maxValue = 15;
        }
        lastIdleTime = Time.time;
        yearStart = DateTime.Now.AddYears(-15).Year;
        txtPre.text = yearStart.ToString();
        txtNext.text = DateTime.Now.AddYears(-2).Year.ToString();


        AdsManager.Instance.onMRECLoaded += OnMRecAdLoadedEvent;
        AdsManager.Instance.onAppOpenLoaded += OnAppOpenLoadedEvent;
        AdsManager.Instance.onAppOpenHidden += OnAppOpenHiddenEvent;

        Debug.Log(">>>>>>Start register event.......");
    }

    private void OnDestroy()
    {
        if (AdsManager.Instance != null)
        {
            AdsManager.Instance.onMRECLoaded -= OnMRecAdLoadedEvent;
            AdsManager.Instance.onAppOpenLoaded -= OnAppOpenLoadedEvent;
            AdsManager.Instance.onAppOpenHidden -= OnAppOpenHiddenEvent;
        }
    }
    private void OnMRecAdLoadedEvent()
    {
        Debug.Log("OnMRecAdLoadedEvent...............");
        isMRECLoaded = true;
        if (step == LoadingStep.None || step == LoadingStep.Loading)
        {
            AdsManager.Instance.HideMREC();
        }
        if (step == LoadingStep.Selection)
        {
            PlayerPrefs.SetInt("select_age", 1);
            AdsManager.Instance.ShowMREC();
        }
        else
        {
            AdsManager.Instance.HideMREC();

            if (AdsManager.Instance.IsOpenAdsReady() && !isShowOpenAds && step == LoadingStep.Loading)
            {
                ForceCompleteLoading();
            }
        }
    }
    private void OnAppOpenLoadedEvent()
    {
        Debug.Log(">>>>>>>>>>>>>OnAppOpenLoadedEvent..........");
        if (!isShowOpenAds && isMRECLoaded && step == LoadingStep.Loading)
        {
            ForceCompleteLoading();
        }

        Debug.Log(">>>>>>>>>ShowOpenAdsFirstOpen OnAppOpenLoadedEvent..........");
    }

    private void ForceCompleteLoading()
    {
        isShowOpenAds = true;
        CancelInvoke("UpdateLoadingProgress");
        loadingProgress.value = loadingProgress.maxValue;
        txtProgress.text = "100%";
        StartCoroutine(WaitToShowOpenAds());
    }
    IEnumerator WaitToShowOpenAds()
    {
        yield return new WaitForSeconds(2f);
        AdsManager.Instance.ShowOpenAds();
        panelLoading.SetActive(false);
    }
    private void OnAppOpenHiddenEvent()
    {
        Debug.Log(">>>>>>>>>>>>>OnAppOpenHiddenEvent...........");
        if (step == LoadingStep.Loading)
        {
            CancelInvoke("UpdateLoadingProgress");
            panelLoading.SetActive(false);

            if (PlayerPrefs.GetInt("select_age", 0) == 0 && isMRECLoaded)
            {
                lastIdleTime = Time.time;
                panelSelectAge.SetActive(true);
                step = LoadingStep.Selection;
                Debug.Log("Time Selection:" + DateTime.Now.ToString("HH:mm:ss"));
            }
            else
                LoadStartScreen();
        }
        else
        {
            if (step == LoadingStep.Selection)
                lastIdleTime = Time.time;
            else
                LoadStartScreen();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //#if UNITY_EDITOR
        //        LoadStartScreen();
        //        return;
        //#endif
        if (PlayerPrefs.GetInt("unlock_all", 0) == 1)
            LoadStartScreen();

        step = LoadingStep.Loading;
        InvokeRepeating("UpdateLoadingProgress", 0.1f, 0.1f);
        //StartCoroutine(FirstLoading());
    }
    float currentProgress = 0;
    void UpdateLoadingProgress()
    {
        if (currentProgress >= loadingProgress.maxValue && step == LoadingStep.Loading)
        {
            CancelInvoke("UpdateLoadingProgress");
            loadingProgress.value = loadingProgress.maxValue;
            txtProgress.text = "100%";

            if (PlayerPrefs.GetInt("select_age", 0) == 0 && AdsManager.Instance.IsOpenAdsReady() && isMRECLoaded)
            {
                if (AdsManager.Instance.IsOpenAdsReady() && !isShowOpenAds)
                {
                    isShowOpenAds = true;
                    AdsManager.Instance.ShowOpenAds();
                }
                else
                {
                    lastIdleTime = Time.time;
                    panelSelectAge.SetActive(true);
                    step = LoadingStep.Selection;
                    panelLoading.SetActive(false);
                }

                Debug.Log("Time Selection:" + DateTime.Now.ToString("HH:mm:ss"));
            }
            else
            {
                if (AdsManager.Instance.IsOpenAdsReady() && !isShowOpenAds)
                {
                    isShowOpenAds = true;
                    AdsManager.Instance.ShowOpenAds();
                }
                else
                    LoadStartScreen();
            }
        }
        else
        {
            if (step == LoadingStep.Loading)
            {
                currentProgress += 0.1f;
                loadingProgress.value = currentProgress;
                var currentText = ((double)currentProgress / (double)loadingProgress.maxValue * 100).ToString();
                txtProgress.text = currentText.Length >= 4 ? currentText.Substring(0, 4) + "%" : currentText + "%";
            }
        }
    }
    //IEnumerator FirstLoading()
    //{
    //    Debug.Log("Begin check time:" + DateTime.Now.ToString("HH:mm:ss"));
    //    yield return new WaitForSeconds(6);

    //    Debug.Log("Begin call show open ads first:" + DateTime.Now.ToString("HH:mm:ss"));
    //    GoogleAdmobManager.Instance.ShowInterOpenFirstOpen();
    //    Debug.Log("End call show open ads first:" + DateTime.Now.ToString("HH:mm:ss"));

    //    LoadStartScreen();
    //}

    public void ButtonNext()
    {
        if (yearStart + 1 > DateTime.Now.AddYears(-2).Year)
            return;
        yearStart += 1;
        RefreshData();
    }
    public void ButtonPre()
    {
        if (yearStart - 1 < DateTime.Now.AddYears(-80).Year)
            return;
        yearStart -= 1;
        RefreshData();
    }

    public void ButtonSelect()
    {
        LoadStartScreen();
    }

    private void RefreshData()
    {
        txtNext.text = (yearStart + 1).ToString();
        txtPre.text = (yearStart - 1).ToString();
        txtSelect.text = yearStart.ToString();
        StartCoroutine(ShowCompleteButton());
    }
    IEnumerator ShowCompleteButton()
    {
        yield return new WaitForSeconds(5);
        buttonComplete.SetActive(true);
    }
    private void LoadStartScreen()
    {
        step = LoadingStep.Finish;
        //PlayerPrefs.SetInt("select_age", 1);
        AdsManager.Instance.HideMREC();
        AdsManager.Instance.InitBanner();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.anyKey && step == LoadingStep.Selection)
        {
            lastIdleTime = Time.time;
        }
        if (Application.internetReachability == NetworkReachability.NotReachable)
            return;

        if (Time.time - lastIdleTime > 10 && step == LoadingStep.Selection)
        {
            Debug.Log(">>>>>>>>>Time Selection timeout:" + DateTime.Now.ToString("HH:mm:ss"));
            LoadStartScreen();
        }
    }

    private void LoadNextScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameObject.SetActive(false);
    }
}