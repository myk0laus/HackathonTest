using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class GameAnalytics : MonoBehaviour
{
    [SerializeField] private CollisionHandler _vehicleCollisionHandler;
    [SerializeField] private RewardedAd _rewardedAd;
    private const string PlayerCrashEventName = "PlayerCrash";
    private const string RewardedViewedEventName = "RewardedAdViewed";

    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();

        _vehicleCollisionHandler.Dead += WriteAnalyticsOfPlayerCrush;
        _rewardedAd.AdWasViewed += WriteAnalyticsOfViewedRewardedAd;
    }

    private void WriteAnalyticsOfPlayerCrush()
    {
        CustomEvent CrashEvent = new CustomEvent(PlayerCrashEventName)
        {
            {"Obstacles", _vehicleCollisionHandler.Score.ScoreProp}
        };

        AnalyticsService.Instance.RecordEvent(CrashEvent);
    }

    private void WriteAnalyticsOfViewedRewardedAd()
    {
        CustomEvent rewardedAdViewedEvent = new CustomEvent(RewardedViewedEventName);
        AnalyticsService.Instance.RecordEvent(rewardedAdViewedEvent);
    }
}