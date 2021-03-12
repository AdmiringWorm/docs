---
Order: 10
xref: gui-installation
Title: Installation
Description: Instructions on how to install Chocolatey GUI
RedirectFrom:
  - en-us/chocolatey-gui/setup/installation/chocolateygui
  - en-us/chocolatey-gui/setup/installation/chocolatey-gui
---

The easiest way to install Chocolatey GUI is to use Chocolatey.  Use the
following command to install the latest version of Chocolatey GUI:

```powershell
choco install chocolateygui
```

## Upgrading Chocolatey GUI

If you already have Chocolatey GUI installed, you can upgrade to the latest
version using the following command:

```powershell
choco upgrade chocolateygui
```

## Installing Beta Versions of Chocolatey GUI

Each time a commit is made into the Chocolatey GUI repository, a build is
performed, and the output is pushed to the Chocolatey GUI MyGet feed.  If you
are interested in using the very latest version of Chocolatey GUI, you can use
the following command to install it:

```powershell
choco upgrade chocolateygui --pre --source="'https://myget.org/f/chocolateygui'"
```
