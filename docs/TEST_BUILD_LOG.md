# Test Build Log

## Legacy accepted behavior

### 1.0.1 - Accepted legacy release

- **Goal:** materialize the accepted rain/wind volume behavior as clean C# source.
- **Behavior:** independent 0–100% rain and wind multipliers; immediate live apply through `SettingChanged`; no per-frame polling; no weather-visual, gameplay, save-data, or unrelated-audio changes.
- **Plugin GUID:** `rainwind.gyk.volume.control`.
- **Verification:** BepInEx loaded the plugin; F1 settings were usable; rain and wind both changed volume immediately while active.
- **Legacy accepted freeze:** `baseline/1.0.1-release` at `40be3ce41d13e33e3ea6ec8ff83f91de416071b3`.
- **Legacy CI:** run `33972541151`; artifact `Rain and Wind Volume Control 1.0.1` (`9971354246`).
- **Accepted DLL SHA-256:** `cc2e6b60adf602effda346beb3e913c8893c5844cedb64737796847a477c9a7c`.
- **User result:** works as intended.
- **Result:** **accepted**.

## 1.1.0 - Public name/package migration candidate

- **Goal:** move the accepted mod into the clean public `RainWindVolumeControls` repository under the name **Rain & Wind Volume Controls**.
- **Changed:** repository/project/assembly/DLL/plugin display name and namespace/class naming; version advanced to 1.1.0.
- **Preserved:** BepInEx GUID `rainwind.gyk.volume.control`, config keys/defaults/ranges, weather sound IDs, runtime patch target, event-driven live-apply behavior.
- **Not intended to change:** rain/wind volume behavior, weather visuals, gameplay, save data, unrelated audio, or steady-state performance.
- **Source basis:** accepted legacy 1.0.1 behavior documented above.
- **Build:** pending clean public CI from `dev/1.1.0`.
- **Requested smoke test after successful build:** install only the new DLL, confirm F1 shows Rain Volume (%) and Wind Volume (%), then verify both rain and wind change immediately while active.
- **Result:** **pending build/smoke test**.
