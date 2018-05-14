using System;
using System.Collections.Generic;
using System.Text;

namespace Datastore
{
    public interface IEntity
    {
        EntityState entity_state { get; set; }
    }

    public enum EntityState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}
