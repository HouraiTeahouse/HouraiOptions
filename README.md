# Hourai Options

A Unity3D library for creating, managing, and persisting user facing game
settings and options in a straightfoward, asset based manner.

By default, these values for these are stored in PlayerPrefs in an unencrypted
form. The expectation is that these values make no signifigant impact on the
game.

# Installation
In Unity 2018.3 and later, add the following to your `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.houraiteahouse.options": "1.0.0"
  },
  "scopedRegistries": [
    {
      "name": "Hourai Teahouse",
      "url": "https://upm.houraiteahouse.net",
      "scopes": ["com.houraiteahouse"]
    }
  ]
}
```

## Usage

### Creating Options
Options can be created like any other asset and edited in the Editor via the
`Create > Option` menu item.

For ease of general access in code, it's actually advisable to store option
assets under a Resources folder or using Addressables. This makes fetching all
available game options simple via well known Unity APIs.

### Reading/Setting Option Values
Option assets can be referred to just like any other asset. Serialize a
reference to a given option in a MonoBehaviour or Scriptable object:

```csharp
public class TestScript : MonoBehavior {

  // Serialized!
  public Option MyOption;

  public void GetOptionValue() {
    // Reading values is simple. Note that invalid type conversions will fail.
    var optionValue = MyOption.Read<float>();
    Debug.Log(optionValue);
  }

  public void SetOptionValue() {
    // Setting values is simple. Note that invalid type conversions will fail.
    MyOption.Set<float(1.3, 0);

    // Setting values can change the interpretation at runtime, but are not
    // automatically saved to the backing store. Calling Save() will persist the
    // the value such that it holds across game sessions.
    MyOption.Save();
  }

}
```

### Reading Option Metadata
Option assets have their metadata readable from each asset as well:

```
option.Path            The key under which the option is stored in the backing store.
option.Type            Choice of [Integer, Float, Enum]
option.MinValue        The minimum value the option can take on.
option.MaxValue        The maximum value the option can take on.

option.Category        What category the option falls under. Useful for grouping
                       similar options together (i.e. Graphics, Audio, etc.)
option.DisplayName     If rendered by a UI, what would the display name be.
option.SortOrder       If rendered by a UI, what priority does this option take.

option.EnumType        The fully qualified name of the underlying C# type for the
                       enum
option.EnumOptions     Individual enum value metadata.
```

### Listening for Changes
Changes can be listened to via Unity Events. Each Option has a `OnValueChanged`
event that can be edited from the Editor or programmatically listened to.

### Changing the backing storage
Changing the static property, `Option.Storage` can alter the backing store
behavior. Implement an alternative `IOptionSotrage` class and substitute it in.
By default, this is a `PlayerPrefsOptionsStorage` object, whihch uses Unity's
PlayerPrefs as a backing store.
