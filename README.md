# Unity Extensions while working on components on C#

## Usage/Examples
```cs
using StinkySteak.ComponentExtensions;

public class Player : MonoBehaviour
{
    if (transform.TryGetComponentInParent(out PlayerParent component))
    {

    }
}

```

### Available API


## API Reference

| Parameter     | Description                |
| :--------  | :------------------------- |
| HasComponent | Check component availability |
| TryGetComponentInParent    | search component in parent |
| TryGetComponentInParentUnsafe     | returns error on null parent |
| TryGetComponentOrInParent      | Try find component in this transform, if null, search in parent |
