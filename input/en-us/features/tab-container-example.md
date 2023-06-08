---
Order: 1
xref: tab-container-example
Title: Tab Container Example
Description: The shows an example on how tab containers using shortcodes can be used
---

> :choco-warning: **WARNING**
>
> Nesting tab containers is not possible. If this is wanted to be added, it is required to to use HTML + Markdown.

<?# TabContainer ?>

<?# Tab Title=" Automatic Id. " ?>

This tab only specifies the absolute minimum, it only specifies the `Title` of the shortcode.
This means that the identifier of both the tab and the tab content will be automatically generated based on the specified title.
To logic for this is to lowercase the identifier, and replace any characters that is not a letter or a digit with a dash (`-`).

See the following code for an example on how this type of tab can be generated.

```xml
<?# TabContainer ?>

<?# Tab Title="Automatic Id" Active="True" ?>

The content we wish to show.

<?#/ Tab ?>

<?#/ TabContainer ?>
```

<?#/ Tab ?>

<?# Tab Title="Initial Tab" Active="True" ?>

This is the initial tab that will be shown when the URL does not contain any fragment.
This will be shown by default because it is marked as Active.

See the following code for an example on how this type of tab can be generated.

```xml
<?# TabContainer ?>

<?# Tab Title="Initial Tab" Active="True" ?>

The content we wish to show.

<?#/ Tab ?>

<?#/ TabContainer ?>
```

<?#/ Tab ?>

<?# Tab Title="Manual ID" Id="Use this identifier, please" ?>

This tab specifies the identifier that we want to use. While this identifier will be respected, we will still try to normalize the identifier by making it lowercase, and replace any characters that is not a letter or a digit with a dash (`-`).

See the following code for an example on how this type of tab can be generated.

```xml
<?# TabContainer ?>

<?# Tab Title="Manual ID" Id="Use this identifier, please" Active="True" ?>

The content we wish to show.

<?#/ Tab ?>

<?#/ TabContainer ?>
```

<?#/ Tab ?>

<?# Tab Title="  Disabling update of URL Hash. " NoHash="True" ?>

This tab specifies the property to disable a hash in the URL. This means that even if the user copies the URL, this tab will not be automatically selected.
This can be useful when we want the header to always be used as the URL hash, instead of the tab itself.

See the following code for an example on how this type of tab can be generated.

```xml
<?# TabContainer ?>

<?# Tab Title="Disabling update of URL Hash" NoHash="True" ?>

The content we wish to show.

<?#/ Tab ?>

<?#/ TabContainer ?>
```

<?#/ Tab ?>

<?#/ TabContainer ?>

When switch to the second tab should not update any hash or fragment in the URL.
Updating to the third tab will update the hash.

<?# TabContainer NoHash="True" ?>

<?# Tab Title="Container Hash Disabled 1" Active="True" ?>

When switch to the other tab should not update any hash or fragment in the URL.

```xml
<?# TabContainer NoHash="True" ?>

<?# Tab Title="Container Hash Disabled" Active="True" ?>
Content goes here
<?#/ Tab ?>

<?#/ TabContainer ?>
```

<?#/ Tab ?>

<?# Tab Title="Container Hash Disabled 2" ?>

When switch to the first tab should not update any hash or fragment in the URL.
Updating to the third tab will update the hash.

```xml
<?# TabContainer NoHash="True" ?>

<?# Tab Title="Container Hash Disabled" Active="True" ?>
Content goes here
<?#/ Tab ?>

<?#/ TabContainer ?>
```

<?#/ Tab ?>

<?# Tab Title="Container Hash Enabled" NoHash="False" ?>

When switch to the other tabs, the hash or fragment in the URL should not be updated.

```xml
<?# TabContainer NoHash="True" ?>

<?# Tab Title="Container Hash Enabled" NoHash="False" Active="True" ?>
Content goes here
<?#/ Tab ?>

<?#/ TabContainer ?>
```

<?#/ Tab ?>

<?#/ TabContainer ?>

For future support, you can also make use of an argument on each Tab item that will allow multiple versions of tabs to be used.
The future support for this is hoped to allow switching to a tab in multiple tab containers, and will create buttons without hash fragment support and will not be linkable.
This feature requires specifying a unique id manually.

<?# TabContainer ?>

<?# Tab Title="Multiple Example 1" Id="multi-example-1" AllowMultiple="True" Active="True" ?>

This item uses a class instead of an ID to do the toggling between tabs.
This allows us to extend the support in future to allow multiple tabs on a specific page to be toggled at the same time.

<?#/ Tab ?>

<?# Tab Title="Multiple Example 2" Id="multi-example-2" AllowMultiple="True" ?>

This item uses a class instead of an ID to do the toggling between tabs.
This allows us to extend the support in future to allow multiple tabs on a specific page to be toggled at the same time.

<?#/ Tab ?>

<?#/ TabContainer ?>

<?# TabContainer ?>

<?# Tab Title="Multiple Example 1" Id="multi-example-3" AllowMultiple="True" Active="True" ?>

This item uses a class instead of an ID to do the toggling between tabs.
This allows us to extend the support in future to allow multiple tabs on a specific page to be toggled at the same time.

<?#/ Tab ?>

<?# Tab Title="Multiple Example 2" Id="multi-example-4" AllowMultiple="True" ?>

This item uses a class instead of an ID to do the toggling between tabs.
This allows us to extend the support in future to allow multiple tabs on a specific page to be toggled at the same time.

<?#/ Tab ?>

<?#/ TabContainer ?>
