# Rain & Wind Volume Controls

A small quality-of-life mod for **Graveyard Keeper** that adds independent volume controls for rain and wind without changing the visual weather effects.

## Features

- Separate rain volume: 0–100%
- Separate wind volume: 0–100%
- Changes apply immediately while weather is active
- Event-driven configuration updates; no per-frame polling
- Does not modify save data, weather visuals, gameplay, or unrelated audio

## Compatibility

- Graveyard Keeper 1.407 (tested on Steam/Windows)
- BepInEx 5.x (tested with 5.4.23.5)
- Configuration Manager 18.4.1 tested for the optional in-game F1 sliders

Mods that directly control the same weather audio groups may override or compound the volume changes.

## Requirements

Install the Graveyard Keeper BepInEx 5 Pack or an equivalent BepInEx 5 setup. Configuration Manager is needed only for the in-game F1 sliders; BepInEx can still store the settings in its normal config file without it.

## Installation

Copy `RainWindVolumeControls.dll` into:

`Graveyard Keeper/BepInEx/plugins/`

Launch the game and press **F1** to adjust **Rain Volume (%)** and **Wind Volume (%)** when Configuration Manager is installed.

## Status

Current stable version: **1.1.0**.
