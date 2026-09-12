# Rain & Wind Volume Controls — Project Rules

The global engineering baseline for this repository is `666drjekyll666-cloud/DevRules`. Before substantive implementation, read `ENGINEERING_RULES.md`, `CI_POLICY.md`, `GIT_WORKFLOW.md`, and `PROJECT_BOOTSTRAP.md` there. This file contains only project-specific additions and explicit exceptions.

## Project identity and scope

- Public project: **Rain & Wind Volume Controls**.
- Game: `Graveyard Keeper 1.407`.
- Repository: `666drjekyll666-cloud/RainWindVolumeControls`.
- Canonical project: `RainWindVolumeControls.csproj`.
- Canonical runtime source: `src/RainWindVolumeControls.cs`.
- Stable BepInEx GUID: `rainwind.gyk.volume.control`.
- Scope: independent player-facing volume controls for rain and wind while preserving weather visuals and unrelated audio/gameplay behavior.

Preserve the accepted lightweight architecture:

- no per-frame polling solely for configuration;
- no repeated hierarchy/global scans during steady-state use;
- no save-data mutation;
- no change to weather visuals;
- changes apply through the narrow verified weather-audio path.

Do not turn this into a general audio mixer or weather overhaul without explicit user approval.

## Public/research boundary

This public repository contains only redistributable project material: our source, documentation, build definitions, and our own release binaries/assets. Reverse-engineering material that genuinely needs retention belongs in the private `666drjekyll666-cloud/GraveyardKeeperResearch` repository; durable verified facts needed by production belong in public project documentation.

## Repository and release contract

- `main` is the accepted stable public line.
- Runtime or packaging candidates remain off `main` until the required acceptance gate is satisfied.
- Every numbered DLL handed to the user is immutable and tied to exact source.
- `docs/TEST_BUILD_LOG.md` is the durable test-build record.
- Public stable binaries are published through GitHub Releases after acceptance.
- For development/test handoff, the user prefers a ready raw versioned DLL such as `Rain & Wind Volume Controls 1.2.0.dll`, not a ZIP.
- For end-user installation and public distribution surfaces such as Nexus, the canonical installed filename is `RainWindVolumeControls.dll` with no version in the filename; version identity belongs in plugin metadata and the surrounding release/store entry.
- A filename-only rename of an already accepted DLL for public packaging is allowed only when the bytes are unchanged and the accepted SHA-256 still matches.
- Existing historical releases do not need retroactive repackaging solely to adopt the stable installed filename convention.

## CI policy for this repository

Follow `DevRules/CI_POLICY.md` and `DevRules/GIT_WORKFLOW.md`.

- Use hosted CI only at coherent candidate/handoff boundaries.
- Documentation-only changes do not require hosted CI.
- Windows remains the canonical runner until a cheaper runner is explicitly proven equivalent for this project.
- A clean Release build is required before a new DLL is handed to the user.
- After acceptance, publish the exact tested artifact to GitHub Releases; do not rebuild different bytes under the same version.

## Long-lived sources of truth

Use `README.md`, `CHANGELOG.md`, `docs/MIGRATION_PROVENANCE.md`, `docs/TEST_BUILD_LOG.md`, the canonical source/project files, and current public repository history. Historical pre-public evidence remains available in `666drjekyll666-cloud/RainAndWindVolumeControl-legacy-private`.

When chat memory conflicts with accepted repository evidence, investigate the conflict before changing code.
