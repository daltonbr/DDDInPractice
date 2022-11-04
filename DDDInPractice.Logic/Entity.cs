namespace DDDInPractice.Logic;

public abstract class Entity //: IEquatable<Entity> not implemented as violates YAGNI
{
    // protected Entity(long id)
    // {
    //     Id = id;
    // }

    // Should this be 'readonly' to avoid changing states - see GetHashCode warning
    // Should use guid's or long's?
    public long Id { get; private set; }

    // public bool Equals(Entity? other)
    // {
    //     // var other = obj as Entity;
    //     // return Equals(other);
    //
    //     return this.Equals(other as object);
    // }

    public override bool Equals(object? obj)
    {
        var other = obj as Entity;
        if (ReferenceEquals(other, null))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (this.GetType() != other.GetType())
        {
            return false;
        }

        if (Id == 0 || other.Id == 0)
        {
            return false;
        }

        return this.Id == other.Id;
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        {
            return true;
        }

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (this.GetType().ToString() + Id).GetHashCode();
    }
}