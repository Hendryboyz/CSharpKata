using System;

namespace Kata
{
    public class ArgSpec
    {
        public Type Type { get; set; }
        public string Flag { get; set; }
        public object Default { get; set; }
    }
}
