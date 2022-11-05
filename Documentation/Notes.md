# DDD in Practice

Ids long vs GUID vs HiLo

```cpp
public abstract class Entity
{
    public Guid Id { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}
```

## Repositories

```cpp
var repository = new SnackMachineRepository();
SnackMachine snackMachine = repository.GetById(id);
```

One repository per aggregate

e.g.

- `SnackMachineRepository` (this repository should supply `SnackMachine` and `Slot` through eager or lazy loading)
- `SnackRepository`

Repositories should receive only the aggregate root.

How to get a sub-entity?
We should get it indirectly through the aggregate root.
Some helper methods are possible like this.

```cpp
var repository = new SnackMachineRepository();
SnackMachine snackMachine = repository.GetBySlotId(slotId);
```

### Summary

- Repositories encapsulate all communication with the external storage.
  - Single repository per each aggregate
  - Public API works with aggregate root only
  - Perform persistence of sub-entities behind the scenes
- Define reference data in your domain model explicitly.

