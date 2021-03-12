---
Order: 40
xref: use-delayed-search
Title: Use Delayed Search
Description: Enables live search, which returns results after a short delay without clicking the search button.
---

By default, when viewing the `This PC` source in Chocolatey GUI, anything that you type into the search box at the top
of the screen will, after a short delay, filter the list of packages to what you have typed in.  Some people prefer that
the search isn't executed until they are finished typing, and actually press the enter key on the keyboard.  Enabling
this feature toggles it so that pressing the entry key is a requirement for the search to be performed.

![Use Delayed Search Enabled](/assets/images/chocolatey-gui/feature_use_delayed_search_enabled.png "Use Delayed Search Enabled")

## Resources

Below is a short video which shows this feature in action:

## Example

This feature can be enabled, for the currently logged in user, by running the following command:

```powershell
chocolateyguicli feature enable --name="'UseDelayedSearch'"
```

This feature can be disabled, for the currently logged in user, by running the following command:

```powershell
chocolateyguicli feature disable --name="'UseDelayedSearch'"
```

Or, to enable/disable it globally at the machine level, run the following commands:

```powershell
chocolateyguicli feature enable --name="'UseDelayedSearch'" --global

chocolateyguicli feature disable --name="'UseDelayedSearch'" --global
```


## Default Value

The default value for this feature is disabled.

## Availability

The ability to control this feature from the Chocolatey GUI Settings screen has existed since Chocolatey GUI v0.16.0.

The ability to control this feature from the command line using `chocolateyguicli` has existed since Chocolatey GUI
v0.17.0.
