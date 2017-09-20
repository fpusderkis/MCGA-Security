﻿using System;
using ASF.Framework.Utilities;
using Kuntur.Framework.Model.General;

namespace Kuntur.Framework.Model.Security
{
    public partial class Email : Entity
    {
        public Email()
        {
            Id = GuidComb.GenerateComb();
            DateCreated = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public string EmailTo { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string NameTo { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
