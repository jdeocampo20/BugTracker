using System;
using BugTracker.Application.Interfaces;

namespace BugTracker.Infrastructure
{
    public class MachineDateTime : IMachineDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
