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

## 1.1.0 - Accepted public name/package migration

- **Goal:** move the accepted mod into the clean public `RainWindVolumeControls` repository under the name **Rain & Wind Volume Controls**.
- **Changed:** repository/project/assembly/DLL/plugin display name and namespace/class naming; version advanced to 1.1.0.
- **Preserved:** BepInEx GUID `rainwind.gyk.volume.control`, config keys/defaults/ranges, weather sound IDs, runtime patch target, event-driven live-apply behavior.
- **Not changed:** rain/wind multiplier logic, weather visuals, gameplay, save data, unrelated audio, or steady-state performance.
- **Source equivalence check:** compared accepted legacy 1.0.1 source with 1.1.0. After normalizing the renamed namespace/class/plugin display name and version string, the runtime implementation is unchanged. Project target/framework/compiler settings and package dependencies are likewise unchanged apart from project/assembly/source names.
- **Source commit:** `f27c489075b7091d41a04609303b91995fdcfcef`.
- **Accepted freeze:** `baseline/1.1.0-accepted` at the same source commit.
- **CI:** public GitHub Actions run `34611974218` succeeded on `windows-latest`; artifact `RainWindVolumeControls-1.1.0` (`10268822659`).
- **Accepted DLL SHA-256:** `aa422a7ebe16071c6bd45d7fd6590149953aa2cdd235a6e67b6a4fb8aadb9a28`.
- **User smoke test:** the new DLL loaded in Graveyard Keeper and Configuration Manager displayed both **Rain Volume (%)** and **Wind Volume (%)** controls.
- **Weather retest:** not repeated because rain/wind are irregular runtime events and the weather-control implementation itself was verified source-equivalent to the already accepted 1.0.1 behavior.
- **Result:** **accepted**.
