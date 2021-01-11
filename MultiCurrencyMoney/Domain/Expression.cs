using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface Expression
    {
        Money Reduce(string to);
    }
}
