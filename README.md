# alabama - dev

Sample project that deploys dotnet projects to AKS using GitHub Actions

## Settings / General / Default Branch

The default branch for this project is `dev`.
This is the branch that will be used for all development work
The `staging` branch is used for staging releases
The `main` branch is used for production releases

## Settings / Branches / Branch protection rules

The `main` branch is protected by the following rules:

- Require a pull request before merging
  - Require at least one approvals
- Require conversation resolution before merging

The `staging` branch is protected by the following rules:

- Require a pull request before merging
  - Require at least one approvals
- Require conversation resolution before merging

## Settings / Code security / Secret scanning

Secret scanning is enabled for this repository
