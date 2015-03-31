using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace pcdServer.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}