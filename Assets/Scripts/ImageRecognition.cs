using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour{

    public ARTrackedImageManager arTrackedImageManager;

    public void OnEnable(){
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    // Update is called once per frame
    public void OnDisable(){
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    //OnImageChangedメソッドが発火する設定はどこで設定している？　もともとあるメソッド？
    public void OnImageChanged(ARTrackedImagesChangedEventArgs args) {
        
        //認識する画像データを読み取っている？
        foreach (var trackedImage in args.updated) {

            //出力させるかどうかの判定をしている？
            if (trackedImage.trackingState == TrackingState.Tracking) {
                trackedImage.gameObject.SetActive(true);
            } else {
                trackedImage.gameObject.SetActive(false);
            }
        
        }
    }
}
