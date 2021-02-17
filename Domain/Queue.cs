using System.Collections.Generic;

namespace Domain
{
    public class Queue
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public ICollection<Turn> Turns { get; set; }
    }
}