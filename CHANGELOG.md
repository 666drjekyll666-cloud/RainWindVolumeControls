# Changelog

## 1.1.0 - Public name/package migration candidate

- Renames the public mod to **Rain & Wind Volume Controls**.
- Renames the project/assembly/DLL to `RainWindVolumeControls`.
- Preserves the existing BepInEx GUID `rainwind.gyk.volume.control` for configuration/plugin identity continuity.
- Preserves the accepted rain/wind volume behavior from 1.0.1.
- No intentional weather, gameplay, save-data, unrelated-audio, or performance behavior changes.

## 1.0.1 - Accepted legacy release

- Added independent 0–100% rain and wind volume controls.
- Volume changes apply immediately while weather is active.
- Does not alter weather visuals, gameplay, save data, or unrelated audio.
- Uses event-driven config updates; no per-frame polling is added.
