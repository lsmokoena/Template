using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datastore.Model
{
    public class Base : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }

        private EntityState _entity_state;

        [NotMapped]
        public EntityState entity_state
        {
            get { return _entity_state; }

            set
            {
                if (value == EntityState.Added)
                {
                    ModifiedDate = DateTime.UtcNow;
                    CreatedDate = DateTime.UtcNow;
                    IsDeleted = false;
                }
                else if (value == EntityState.Modified)
                {
                    ModifiedDate = DateTime.UtcNow;
                }
                else if (value == EntityState.Deleted)
                {
                    ModifiedDate = DateTime.UtcNow;
                    IsDeleted = true;
                }
                _entity_state = value;
            }
        }
    }
}
