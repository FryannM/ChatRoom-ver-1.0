using System;
using System.Collections.Generic;
using System.Text;

namespace Chatroom.Model
{
    public abstract class AEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int Draw { get; set; }
        public virtual int Start { get; set; }
        public virtual int Length { get; set; } = 5;

    }
}
