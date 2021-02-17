using System;
using Domain.Enums;

namespace Domain
{
    public class Turn
    {
        public int Id { get; set; }
        public short Label { get; set; }
        public Gender Gender { get; set; }
        public DateTime ExportTime { get; set; }
        public TimeSpan? CallOffset { get; set; }
        public bool IsActive { get; set; }
        public Queue Queue { get; set; }
    }
}