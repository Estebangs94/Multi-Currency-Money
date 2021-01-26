using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IExpression
    {
        Money Reduce(Bank bank, string to);
    }
}
