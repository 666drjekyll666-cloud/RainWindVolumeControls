using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace RainWindVolumeControls
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public sealed class RainWindVolumeControlsPlugin : BaseUnityPlugin
    {
        internal const string PluginGuid = "rainwind.gyk.volume.control";
        internal const string PluginName = "Rain & Wind Volume Controls";
        internal const string PluginVersion = "1.1.0";

        internal static ConfigEntry<float> RainVolume;
        internal static ConfigEntry<float> WindVolume;
        internal static float LastRainAmount = -1f;
        internal static float LastWindAmount = -1f;

        private Harmony _harmony;

        private void Awake()
        {
            RainVolume = Config.Bind(
                "Volume",
                "Rain Volume (%)",
                0.5f,
                new ConfigDescription(
                    "Rain: 0-100%",
                    new AcceptableValueRange<float>(0f, 1f)));

            WindVolume = Config.Bind(
                "Volume",
                "Wind Volume (%)",
                0.5f,
                new ConfigDescription(
                    "Wind: 0-100%",
                    new AcceptableValueRange<float>(0f, 1f)));

            RainVolume.SettingChanged += OnVolumeSettingChanged;
            WindVolume.SettingChanged += OnVolumeSettingChanged;

            _harmony = new Harmony(PluginGuid);
            _harmony.PatchAll();

            Logger.LogInfo($"{PluginName} {PluginVersion} loaded.");
        }

        private void OnDestroy()
        {
            if (RainVolume != null)
            {
                RainVolume.SettingChanged -= OnVolumeSettingChanged;
            }

            if (WindVolume != null)
            {
                WindVolume.SettingChanged -= OnVolumeSettingChanged;
            }

            _harmony?.UnpatchSelf();
        }

        private static void OnVolumeSettingChanged(object sender, EventArgs e)
        {
            WeatherVolumePatch.ApplyCurrent();
        }
    }

    /// <summary>
    /// Applies player-configured multipliers only to Graveyard Keeper's two weather
    /// ambience groups. The raw game-provided values are cached so changing a slider
    /// can immediately reapply the current weather intensity without polling per frame.
    /// </summary>
    [HarmonyPatch]
    internal static class WeatherVolumePatch
    {
        private const string RainSoundId = "rain_environment";
        private const string WindSoundId = "wind_environment";

        private static MethodInfo _setSoundVolume;
        private static MethodInfo _getAudioEngine;

        private static MethodBase TargetMethod()
        {
            Type audioEngineType = AccessTools.TypeByName("SmartAudioEngine");
            if (audioEngineType == null)
            {
                throw new TypeLoadException("Could not find Graveyard Keeper type SmartAudioEngine.");
            }

            _setSoundVolume = AccessTools.Method(
                audioEngineType,
                "SetSoundVolume",
                new[] { typeof(string), typeof(float) });

            _getAudioEngine = AccessTools.PropertyGetter(audioEngineType, "me")
                ?? AccessTools.Method(audioEngineType, "get_me");

            if (_setSoundVolume == null || _getAudioEngine == null)
            {
                throw new MissingMethodException(
                    "Could not resolve SmartAudioEngine.me or SetSoundVolume(string, float).");
            }

            return _setSoundVolume;
        }

        private static void Prefix(string __0, ref float __1)
        {
            if (__0 == RainSoundId)
            {
                RainWindVolumeControlsPlugin.LastRainAmount = __1;
                if (RainWindVolumeControlsPlugin.RainVolume != null)
                {
                    __1 *= RainWindVolumeControlsPlugin.RainVolume.Value;
                }

                return;
            }

            if (__0 == WindSoundId)
            {
                RainWindVolumeControlsPlugin.LastWindAmount = __1;
                if (RainWindVolumeControlsPlugin.WindVolume != null)
                {
                    __1 *= RainWindVolumeControlsPlugin.WindVolume.Value;
                }
            }
        }

        internal static void ApplyCurrent()
        {
            if (_setSoundVolume == null || _getAudioEngine == null)
            {
                return;
            }

            object audioEngine = _getAudioEngine.Invoke(null, null);
            if (audioEngine == null)
            {
                return;
            }

            if (RainWindVolumeControlsPlugin.LastRainAmount >= 0f)
            {
                _setSoundVolume.Invoke(
                    audioEngine,
                    new object[]
                    {
                        RainSoundId,
                        RainWindVolumeControlsPlugin.LastRainAmount
                    });
            }

            if (RainWindVolumeControlsPlugin.LastWindAmount >= 0f)
            {
                _setSoundVolume.Invoke(
                    audioEngine,
                    new object[]
                    {
                        WindSoundId,
                        RainWindVolumeControlsPlugin.LastWindAmount
                    });
            }
        }
    }
}
